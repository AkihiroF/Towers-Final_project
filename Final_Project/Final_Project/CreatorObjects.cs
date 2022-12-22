using Final_Project.Units;

namespace Final_Project;

public static class CreatorObjects
{
    public static ParametersUnit CreateParameters(float hp, float damage, int radiusDamage) =>
        new ParametersUnit(hp, damage, radiusDamage);

    public static Human CreateHuman(ParametersUnit parametersUnit) => new Human(parametersUnit);

    public static Tower CreateTower(ParametersUnit parametersUnit) => new Tower(parametersUnit);
    public static WorldMap CreateWorld(int size) => new WorldMap(size);
    public static UIPrinter CreatePrinter() => new UIPrinter();
    public static Timer CreateTimer( int time) => new Timer(time);
    
}