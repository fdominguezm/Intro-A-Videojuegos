using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("character"); // nombre exacto de la escena del juego
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}