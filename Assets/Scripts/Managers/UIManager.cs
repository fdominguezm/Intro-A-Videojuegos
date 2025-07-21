using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{

    [Header("GUN")]
    [SerializeField] private TMP_Text _gunText;
    [SerializeField] private List<Sprite> _guns;
    [SerializeField] private Image _activeGun;


    private int _ammo;
    private string _weapon;


    [Header("LIFE")]

    [SerializeField] private List<Sprite> _lifeBars;
    [SerializeField] private Image _activeLifebar;

    private int _lifeBarsSize;


    private void Start()
    {
        EventManager.instance.OnLifeChange += OnLifeChange;
        EventManager.instance.OnGunAmmoChange += OnAmmoChange;
        EventManager.instance.OnWeaponChange += OnWeaponChange;
        _gunText.text = string.Empty;
        _lifeBarsSize = _lifeBars.Count;
    }

    private void OnLifeChange(int life, int maxLife)
    {
        int index = Mathf.CeilToInt(((float)life / maxLife) * (_lifeBarsSize - 1));
        index = Mathf.Clamp(index, 0, _lifeBarsSize - 1);
        _activeLifebar.sprite = _lifeBars[index];
    }

    private void OnAmmoChange(int ammo)
    {
        _gunText.text = $"{ammo}";

    }

    private void OnWeaponChange(string name)
    {
        switch (name)
        {
            case "Pistol":
                _activeGun.sprite = _guns[0];
                break;
            case "Shotgun":
                _activeGun.sprite = _guns[1];
                break;
            case "Rifle":
                _activeGun.sprite = _guns[2];
                break;
            case "Thunderifle":
                _activeGun.sprite = _guns[3];
                break;
        }

    }

}