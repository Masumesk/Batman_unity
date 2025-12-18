using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private AudioSource backgroundMusic;

    [SerializeField]
    private AudioSource alertSound;

    

    void Awake()
    {
        //singleton 
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    //پخش صدای پس زمینه
    public void PlayBackground()
    {
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
        alertSound.Stop();
    }

    //پخش صدای alert در استیت
    public void PlayAlert()
    {
        if (!alertSound.isPlaying)
            alertSound.Play();

        backgroundMusic.Stop();
    }

}