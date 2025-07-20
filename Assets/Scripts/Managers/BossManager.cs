
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Image _fire;
    [SerializeField] private TMP_Text _bossLife;

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
        EventManager.instance.OnBurning += OnBurning;
        EventManager.instance.OnBossLifeChange += OnBossLifeChange;
        _fire.gameObject.SetActive(false);
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
        _bossLife.text = $"BOSS: {life}/{maxLife}";
    }

}