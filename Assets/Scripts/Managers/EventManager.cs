using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    static public EventManager instance;

    #region UNITY_EVENTS
    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    #endregion

    #region GAME_MANAGER
    public event Action<bool> OnGameOver;

    public void EventGameOver(bool isVictory)
    {
        if (OnGameOver != null) OnGameOver(isVictory);
    }
    #endregion

    #region UI_FEEDBACK
    public event Action<int, int> OnLifeChange;
    public event Action<int> OnGunAmmoChange;
    public event Action<string> OnWeaponChange;
    public event Action<int> OnGunShoot;
    public event Action OnGunReload;
    public event Action OnPlayerDamage;
    public event Action OnZombieDamage;


    public void Event_LifeChange(int life, int maxLife)
    {
        if (OnLifeChange != null) OnLifeChange(life, maxLife);
    }
    public void Event_GunAmmoChange(int ammo)
    {
        if (OnGunAmmoChange != null) OnGunAmmoChange(ammo);
    }
    public void Event_WeaponChange(string name)
    {
        if (OnWeaponChange != null) OnWeaponChange(name);
    }

    public void Event_OnGunShoot(int weapon)
    {
        if (OnGunShoot != null) OnGunShoot(weapon);
    }

    public void Event_OnGunReload()
    {
        if (OnGunReload != null) OnGunReload();
    }
    public void Event_OnPlayerDamage()
    {
        if (OnPlayerDamage != null) OnPlayerDamage();
    }
    public void Event_OnZombieDamage()
    {
        if (OnZombieDamage != null) OnZombieDamage();
    }

    #endregion
}