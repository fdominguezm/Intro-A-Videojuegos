using System;
using System.Collections.Generic;
using UnityEngine;


public class SwitchWeaponCommand : ICommand
{
    private List<Gun> _gunList;
    private int _weaponIndex;
    private Action<Gun> _onWeaponSwitched;

    public SwitchWeaponCommand(List<Gun> gunList, int weaponIndex, Action<Gun> onWeaponSwitched)
    {
        _gunList = gunList;
        _weaponIndex = weaponIndex;
        _onWeaponSwitched = onWeaponSwitched;
    }

    public void Execute()
    {
        for (int i = 0; i < _gunList.Count; i++)
        {
            _gunList[i].gameObject.SetActive(i == _weaponIndex);
        }

        _onWeaponSwitched?.Invoke(_gunList[_weaponIndex]);
    }
}
