using System.Diagnostics;
using System.Numerics;
using Final_Project.Interfaces;
using Final_Project.Units;

namespace Final_Project;

public class WorldMap
{
    private List<List<string>> _UIMap;
    private List<List<WayPoint>> _units;
    private UIPrinter _printer;
    private Random _rnd;

    public WorldMap(int size)
    {
        _UIMap = new List<List<string>>();
        _units = new List<List<WayPoint>>();
        _rnd = new Random();
        _printer = CreatorObjects.CreatePrinter();
        Timer.OnTikWorld += Tik;
        
        GenerateWorld(size);
    }

    private void GenerateWorld(int size)
    {
        for (int i = 0; i < size; i++)
        {
            _units.Add(new List<WayPoint>());
            _UIMap.Add(new List<string>());
            for (int j = 0; j < size; j++)
            {
                _units[i].Add(new WayPoint(i,j));
                _UIMap[i].Add("0");
            }
        }
        _printer.PrintInformation(_UIMap);
    }

    public void AddHuman(Human human)
    {
        var index = _rnd.Next(0, _units.Count);
        if (_units[index][0].IsActive == false)
        {
            _units[index][0].UnitOnThisPoint = human;
            _units[index][0].IsActive = true;
            foreach (var point in _units[index])
            {
                var wayPoint = point;
                human.AddPointDirection(ref wayPoint);
            }
            _UIMap[index][0] = "E";
            _printer.PrintInformation(_UIMap);
        }
        else
        {
            AddHuman(human);
        }
    }

    public void AddTower(Tower tower, WayPoint point)
    {
        if(point.X >= _units.Count && point.Y >= _units[point.X].Count)
            return;
        var position =_units[point.X][point.Y];
        _UIMap[point.X][point.Y] = "T";
        position.IsActive = true;
        position.UnitOnThisPoint = tower;
    }

    private void MoveHuman()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            for (int j = 0; j < _units[i].Count; j++)
            {
                var point = _units[i][j];
                if (point.IsActive)
                {
                    if (point.UnitOnThisPoint.GetType() == typeof(Human))
                    {
                        var human = (Human)point.UnitOnThisPoint;
                        if (j == _units[i].Count - 1)
                        {
                            _UIMap[i][j] = "0";
                            point.IsActive = false;
                            human.ClearDirection();
                            AddHuman(human);
                            continue;
                        }
                        if(AttackUnits(point))
                            continue;
                        human.Move();
                        _UIMap[i][j] = "0";
                        var posEnemy = human.GetCurrentPoint();
                        _UIMap[posEnemy.X][posEnemy.Y] = "E";
                        j++;
                    }
                }
            }
        }
    }

    private void CheckTowerOnAttack()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            for (int j = 0; j < _units[i].Count; j++)
            {
                var point = _units[i][j];
                if (point.IsActive && point.UnitOnThisPoint.GetType() == typeof(Tower))
                {
                    AttackUnits(point);
                }
            }
        }
    }

    private bool AttackUnits(WayPoint point)
    {
        var unit = point.UnitOnThisPoint;
        var radius = unit.RadiusDamage;
        bool isAttack = false;
        for (int i = -radius; i <= radius; i++)
        {
            for (int j = -radius; j <= radius; j++)
            {
                if(i == 0 && j == 0)
                    continue;
                if(point.X + Math.Abs(i) > _units.Count 
                   && point.Y + Math.Abs(j) > _units[point.X].Count 
                   && point.X + i <= 0
                   && point.Y + j <= 0)
                    continue;
                var targetPoint = _units[i][j];
                if (targetPoint.IsActive && unit.GetType() != targetPoint.UnitOnThisPoint.GetType())
                {
                    unit.Attack(targetPoint.UnitOnThisPoint);
                    isAttack = true;
                }
            }
        }

        return isAttack;
    }

    private void Tik()
    {
        CheckTowerOnAttack();
        MoveHuman();
        _printer.PrintInformation(_UIMap);
    }
}