using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource backgroundMusic;
    public AudioSource alertSound;

    void Awake()
    {
        // Singleton
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayBackground()
    {
        if (!backgroundMusic.isPlaying)
            backgroundMusic.Play();

        alertSound.Stop();
    }

    public void PlayAlert()
    {
        if (!alertSound.isPlaying)
            alertSound.Play();

        backgroundMusic.Stop();
    }

    public void StopAll()
    {
        backgroundMusic.Stop();
        alertSound.Stop();
    }
}