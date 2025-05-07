using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private Image _gameOverImage;
    [SerializeField] private Sprite _defeatSprite;
    [SerializeField] private Sprite _victorySprite;


    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
        _gameOverText.text = string.Empty;
        _gameOverImage.enabled = false;
    }

    private void OnGameOver(bool isVictory)
    {
        _gameOverText.text = isVictory ? "Victoria" : "Derrota";
        _gameOverText.color = isVictory ? Color.cyan : Color.red;
        _gameOverImage.enabled = true;
        _gameOverImage.sprite = isVictory ? _victorySprite : _defeatSprite;
    }

}