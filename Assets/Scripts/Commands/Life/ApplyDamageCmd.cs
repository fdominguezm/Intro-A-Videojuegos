using UnityEngine;

public class ApplyDamageCmd : ICommand
{
    private IDamageable _damageable;
    private int _damage;

    public ApplyDamageCmd(IDamageable damageable, int damage)
    {
        _damageable = damageable;
        _damage = damage;
    }

    public void Execute()
    {
        _damageable.ApplyDamage(_damage);
    }
}