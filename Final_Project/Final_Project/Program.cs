using Final_Project;
using Final_Project.Interfaces;

public class Program
{
    private static void Main()
    {
        var parameterHuman = CreatorObjects.CreateParameters(1,2,4);
        var parameterTower = CreatorObjects.CreateParameters(2, 1, 1);
        var tower_1 = CreatorObjects.CreateTower(parameterTower);
        var human_1 = CreatorObjects.CreateHuman(parameterHuman);
        var human_2 = CreatorObjects.CreateHuman(parameterHuman);
        var world = CreatorObjects.CreateWorld(7);
        world.AddTower(tower_1, new WayPoint(3,4));
        world.AddHuman(human_1);
        world.AddHuman(human_2);
        var timer = CreatorObjects.CreateTimer(2);
    }
}