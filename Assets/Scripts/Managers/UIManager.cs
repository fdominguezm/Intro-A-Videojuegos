using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [Header("GUN")]
    [SerializeField] private TMP_Text _gunText;
    private int _ammo;
    private string _weapon;


    [Header("LIFE")]
    [SerializeField] private TMP_Text _lifeText;


    private void Start()
    {
        EventManager.instance.OnLifeChange += OnLifeChange;
        EventManager.instance.OnGunAmmoChange += OnAmmoChange;
        EventManager.instance.OnWeaponChange += OnWeaponChange;
        _lifeText.text = string.Empty;
        _gunText.text = string.Empty;
    }

    private void OnLifeChange(int life, int maxLife)
    {
        _lifeText.text = $"{life}/{maxLife}";
    }

    private void OnAmmoChange(int ammo)
    {
        _ammo = ammo;
        UpdateGunText();
    }

    private void OnWeaponChange(string name)
    {
        _weapon = name;
        UpdateGunText();
    }
    private void UpdateGunText()
    {
        _gunText.text = $"{_weapon}:{_ammo}";
    }

}