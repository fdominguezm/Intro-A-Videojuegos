using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPreviewManager : MonoBehaviour
{
    private string sceneToLoad = "SecondPreviewScene"; 

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}