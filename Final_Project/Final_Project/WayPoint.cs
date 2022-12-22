namespace Final_Project.Interfaces;

public class WayPoint
{
    public WayPoint(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; private set; }
    public int Y { get; private set; }
    public ABaseClassUnit UnitOnThisPoint;
    public bool IsActive = false;
}