using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
    }

    private void OnGameOver(bool isVictory)
    {
        // _isGameOver = true;
        _isVictory = isVictory;

        string debugMessage = isVictory ? "Victoria" : "Derrota";
        Debug.Log(debugMessage);
    }
}
