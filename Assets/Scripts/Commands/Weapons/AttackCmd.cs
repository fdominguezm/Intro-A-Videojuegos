using UnityEngine;

public class AttackCmd : ICommand
{
    private Gun _gun;

    public AttackCmd(Gun gun)
    {
        _gun = gun;
    }

    public void Execute()
    {
        _gun.Attack();
    }
}