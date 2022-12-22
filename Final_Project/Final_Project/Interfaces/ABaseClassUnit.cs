namespace Final_Project.Interfaces;

public abstract class ABaseClassUnit : IUnit
{
    private float _currentHp;
    private float _damage;
    public readonly int RadiusDamage;

    public ABaseClassUnit(ParametersUnit parameters)
    {
        _currentHp = parameters.Hp;
        _damage = parameters.Damage;
        RadiusDamage = parameters.RadiusDamage;
    }
    public void GetDamage(float damage)
    {
        _currentHp -= damage;
        if(_currentHp <= 0) Dead();
    }

    public void Attack(IUnit target)
    {
        target.GetDamage(_damage);
    }

    protected abstract void Dead();
}