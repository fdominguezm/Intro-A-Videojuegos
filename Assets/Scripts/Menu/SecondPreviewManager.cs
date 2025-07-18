using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondPreview : MonoBehaviour
{
    private string sceneToLoad = "character"; 

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}