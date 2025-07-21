using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPreview : MonoBehaviour
{
    private string sceneToLoad = "Boss"; 

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}