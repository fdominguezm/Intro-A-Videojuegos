using UnityEngine;

public class ReloadCmd : ICommand
{
    private Gun _gun;

    public ReloadCmd(Gun gun)
    {
        _gun = gun;
    }

    public void Execute()
    {
        _gun.Reload();
    }
}