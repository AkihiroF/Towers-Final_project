using Final_Project.Interfaces;

namespace Final_Project.Units;

public class Human : ABaseClassUnit
{
    private List<WayPoint> _direction;
    private int _currentPosition;
    public Human(ParametersUnit parameters) : base(parameters)
    {
        _currentPosition = 0;
        _direction = new List<WayPoint>();
    }

    public void AddPointDirection(ref WayPoint point)
    {
        _direction.Add(point);
    }

    public void ClearDirection()
    {
        _direction = new List<WayPoint>();
        _currentPosition = 0;
    }
    public void Move()
    {
        if (_currentPosition + 1 < _direction.Count)
        {
            if (_direction[_currentPosition + 1].IsActive)
            {
                return;
            }
        }
        _direction[_currentPosition].IsActive = false;
        _currentPosition++;
        _direction[_currentPosition].UnitOnThisPoint = this;
        _direction[_currentPosition].IsActive = true;
    }

    public WayPoint GetCurrentPoint() => _direction[_currentPosition];
    protected override void Dead()
    {
        
    }
}