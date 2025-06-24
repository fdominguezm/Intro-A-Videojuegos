using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}