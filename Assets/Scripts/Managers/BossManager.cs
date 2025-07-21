
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class BossManager : MonoBehaviour
{
    [SerializeField] private Image _fire;
    [SerializeField] private List<Sprite> _allBossLifeBars;
    [SerializeField] private Image _activeBossLifeBar;

    private int _allBossLifeBarsSize;


    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
        EventManager.instance.OnBurning += OnBurning;
        EventManager.instance.OnBossLifeChange += OnBossLifeChange;
        _fire.gameObject.SetActive(false);
        _allBossLifeBarsSize = _allBossLifeBars.Count;
    }
    private void OnGameOver(bool isVictory)
    {
        if (isVictory)
        {
            SceneManager.LoadScene("EndVictory");
        }
        else
        {
            SceneManager.LoadScene("EndDefeat");
        }

    }
    public void OnBurning(bool isBurning)
    {
        _fire.gameObject.SetActive(isBurning);
    }
    public void OnBossLifeChange(int life, int maxLife)
    {
        if (life < 0)
        {
            life = 0;
        }

        int index = Mathf.CeilToInt(((float)life / maxLife) * (_allBossLifeBarsSize - 1));
        index = Mathf.Clamp(index, 0, _allBossLifeBarsSize - 1);
        _activeBossLifeBar.sprite = _allBossLifeBars[index];
        
    }

}