using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Loading"); // nombre exacto de la escena del juego
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }

    public void HowToPlay()
    {
        Debug.Log("How to play");
        SceneManager.LoadScene("Instrucciones");
    }
}