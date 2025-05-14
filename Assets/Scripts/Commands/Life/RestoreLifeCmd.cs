using UnityEngine;

public class RestoreLifeCmd : ICommand
{
    private IDamageable _damageable;
    private int _heal;

    public RestoreLifeCmd(IDamageable damageable, int heal)
    {
        _damageable = damageable;
        _heal = heal;
    }

    public void Execute()
    {
        _damageable.RestoreLife(_heal);
    }
}