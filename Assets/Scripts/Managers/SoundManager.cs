using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip _victoryClip;
    [SerializeField] private AudioClip _defeatClip;


    public AudioSource AudioSource => GetComponent<AudioSource>();

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
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
}