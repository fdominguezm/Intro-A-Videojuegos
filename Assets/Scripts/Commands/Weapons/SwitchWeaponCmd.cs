using System;
using System.Collections.Generic;
using UnityEngine;


public class SwitchWeaponCmd : ICommand
{
    private List<Gun> _gunList;
    private WeaponIndex _weaponIndex;
    private Action<Gun> _onWeaponSwitched;

    public SwitchWeaponCmd(List<Gun> gunList, WeaponIndex weaponIndex, Action<Gun> onWeaponSwitched)
    {
        _gunList = gunList;
        _weaponIndex = weaponIndex;
        _onWeaponSwitched = onWeaponSwitched;
    }

    public void Execute()
    {

        for (int i = 0; i < _gunList.Count; i++)
        {
            _gunList[i].gameObject.SetActive(i == (int)_weaponIndex);
        }

        _onWeaponSwitched?.Invoke(_gunList[(int)_weaponIndex]);
    }
}
