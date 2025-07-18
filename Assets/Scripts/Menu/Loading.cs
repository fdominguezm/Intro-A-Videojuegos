using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public float loadingTime = 3f;
    private string sceneToLoad = "FirstPreviewScene"; 

    private async void Start()
    {
        Debug.Log("Inicio de pantalla de carga"); 
        await Task.Delay((int)(loadingTime * 1000));
        Debug.Log("Cambiando a escena: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}