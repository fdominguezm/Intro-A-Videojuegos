using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip _victoryClip;
    [SerializeField] private AudioClip _defeatClip;

    public AudioSource audioSource;

    [Header("Gun Sounds")]
    [SerializeField] private List<AudioClip> shotClips;
    [SerializeField] private AudioClip reloadClip;

    [Header("Hit Sounds")]
    [SerializeField] private AudioClip playerDamageClip;
    [SerializeField] private AudioClip zombieDamageClip;





    public AudioSource AudioSource => GetComponent<AudioSource>();

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
        EventManager.instance.OnGunShoot += OnGunShoot;
        EventManager.instance.OnGunReload += OnGunReload;
        EventManager.instance.OnPlayerDamage += OnPlayerDamage;
        EventManager.instance.OnZombieDamage += OnZombieDamage;
    }

    private void OnGameOver(bool isVictory)
    {
        if (isVictory)
        {
            AudioSource.PlayOneShot(_victoryClip);
        }
        else
        {
            AudioSource.PlayOneShot(_defeatClip);
        }
    }
    private void OnGunShoot(int weapon)
    {
        AudioSource.PlayOneShot(shotClips[weapon]);
    }

    private void OnGunReload()
    {
        AudioSource.PlayOneShot(reloadClip);
    }

    private void OnPlayerDamage()
    {
        AudioSource.PlayOneShot(playerDamageClip);
    }
    private void OnZombieDamage()
    {
        AudioSource.PlayOneShot(zombieDamageClip);
    }
}