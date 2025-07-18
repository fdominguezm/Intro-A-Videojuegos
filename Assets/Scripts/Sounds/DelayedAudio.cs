using UnityEngine;

public class DelayedAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayInSeconds = 5f;

    void Start()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private System.Collections.IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        audioSource.Play();
    }
}