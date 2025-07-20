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
    public event Action KilledZombie;

    public void EventGameOver(bool isVictory)
    {
        if (OnGameOver != null) OnGameOver(isVictory);
    }

    public void EventZombieKilled()
    {
        if (KilledZombie != null) KilledZombie();
    }
    #endregion

    #region UI_FEEDBACK
    public event Action<int, int> OnLifeChange;
    public event Action<int> OnGunAmmoChange;
    public event Action<string> OnWeaponChange;

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

    public event Action<DamageType> OnDamage;
    public event Action OnReload;
    public event Action<WeaponIndex> OnShot;
    public void Event_OnDamage(DamageType type)
    {
        if (OnDamage != null) OnDamage(type);
    }
    public void Event_OnReload()
    {
        if (OnReload != null) OnReload();
    }
    public void Event_OnShot(WeaponIndex weapon)
    {
        if (OnShot != null) OnShot(weapon);
    }

    #endregion

    #region BOSS_UI
    public event Action<bool> OnBurning;
    public event Action<int, int> OnBossLifeChange;

    public void EventBurning(bool isBurning)
    {
        if (OnBurning != null) OnBurning(isBurning);
    }
    public void EventBossLifeChange(int life, int maxLife)
    {
        if (OnBossLifeChange != null) OnBossLifeChange(life, maxLife);
    }

    #endregion
}