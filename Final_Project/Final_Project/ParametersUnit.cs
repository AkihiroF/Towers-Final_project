namespace Final_Project;

public struct ParametersUnit
{
    public ParametersUnit(float hp, float damage, int radiusDamage)
    {
        Hp = hp;
        Damage = damage;
        RadiusDamage = radiusDamage;
    }

    public readonly float Hp;
    public readonly float Damage;
    public readonly int RadiusDamage;
    
}