using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private int _zombieCount;

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
        EventManager.instance.KilledZombie += KilledZombie;
    }

    private void OnGameOver(bool isVictory)
    {
        // _isGameOver = true;
        _isVictory = isVictory;

        string debugMessage = isVictory ? "Victoria" : "Derrota";

        if (isVictory)
        {
            SceneManager.LoadScene("Boss");
        }
        else
        {
            SceneManager.LoadScene("EndDefeat");
        }

    }

    private void KilledZombie()
    {
        _zombieCount--;
        if (_zombieCount == 0)
        {
            EventManager.instance.EventGameOver(true);
        }

    }
}
