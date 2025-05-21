using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    // [SerializeField] private AudioClip _victoryClip;
    // [SerializeField] private AudioClip _defeatClip;

    [Header("Damage")]
    [SerializeField] private AudioClip _characterClip;
    [SerializeField] private AudioClip _zombieClip;
    [SerializeField] private AudioClip _wallClip;

    [Header("Weapons")]
    [SerializeField] private AudioClip _reloadClip;
    [SerializeField] private AudioClip _pistolClip;
    [SerializeField] private AudioClip _shotgunClip;
    [SerializeField] private AudioClip _rifleClip;


    public AudioSource AudioSource => GetComponent<AudioSource>();

    private void Start()
    {
        // EventManager.instance.OnGameOver += OnGameOver;
        EventManager.instance.OnDamage += OnDamage;
        EventManager.instance.OnReload += OnReload;
        EventManager.instance.OnShot += OnShot;
    }

    // private void OnGameOver(bool isVictory)
    // {
    //     if (isVictory)
    //     {
    //         AudioSource.PlayOneShot(_victoryClip);
    //     }
    //     else
    //     {
    //         AudioSource.PlayOneShot(_defeatClip);
    //     }
    // }

    public void OnDamage(DamageType type)
    {
        switch (type)
        {
            case DamageType.Character:
                AudioSource.PlayOneShot(_characterClip);
                break;
            case DamageType.Zombie:
                AudioSource.PlayOneShot(_zombieClip);
                break;
            case DamageType.Wall:
                AudioSource.PlayOneShot(_wallClip);
                break;
        }
    }

    public void OnShot(WeaponIndex weapon)
    {
        switch (weapon)
        {
            case WeaponIndex.pistol:
                AudioSource.PlayOneShot(_pistolClip);
                break;
            case WeaponIndex.shotgun:
                AudioSource.PlayOneShot(_shotgunClip);
                break;
            case WeaponIndex.rifle:
                AudioSource.PlayOneShot(_rifleClip);
                break;
        }
    }

    public void OnReload()
    {
        AudioSource.PlayOneShot(_reloadClip);
    }
}