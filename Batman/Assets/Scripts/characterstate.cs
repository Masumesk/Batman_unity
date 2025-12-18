using UnityEngine;
using System.Collections;


public class characterstate : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float stealthSpeed = 2f;
    public float alertSpeed = 7f;

   
    public float normalLight = 1f;
    public float stealthLight = 0.3f;
    public float alertLight = 1.5f;

    
    public Color alertColorRed = Color.red;
    public Color alertColorBlue = Color.blue;

    
    public AudioSource alertAudio;

   
    public SpriteRenderer backgroundSprite;
    public Color normalBackgroundColor = Color.white;
    public Color stealthBackgroundColor = new Color(0.3f, 0.3f, 0.3f);
    public Color alertBackgroundColor = new Color(0.8f, 0.2f, 0.2f);

    private float currentSpeed;
    private Coroutine flashRoutine;

    private GameState lastState;

    void Update()
    {
        if (!gameObject.activeInHierarchy)
            return;

        GameState current = StateManager.Instance.currentState;

        if (current != lastState)
        {
            ApplyState(current);
            lastState = current;
        }
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }

    void ApplyState(GameState state)
    {
       
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
            flashRoutine = null;
        }

       
        if (state == GameState.Normal)
        {
            currentSpeed = normalSpeed;

            

            if (alertAudio != null && alertAudio.isPlaying)
                alertAudio.Stop();

            if (backgroundSprite != null)
                backgroundSprite.color = normalBackgroundColor;
        }

       
        else if (state == GameState.Stealth)
        {
            currentSpeed = stealthSpeed;

            

            if (alertAudio != null && alertAudio.isPlaying)
                alertAudio.Stop();

            if (backgroundSprite != null)
                backgroundSprite.color = stealthBackgroundColor;
        }

       
        else if (state == GameState.Alert)
        {
            currentSpeed = alertSpeed;

            if (alertAudio != null && !alertAudio.isPlaying)
                alertAudio.Play();
            flashRoutine=StartCoroutine(FlashLight());
        }
    }

    IEnumerator FlashLight()
    {
        while (true)
        {
            if (backgroundSprite != null)
                backgroundSprite.color = alertColorBlue;

            yield return new WaitForSeconds(0.2f);

            if (backgroundSprite != null)
                backgroundSprite.color = alertColorRed;

            yield return new WaitForSeconds(0.2f);
        }
    }
}