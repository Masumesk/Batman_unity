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

    
    // public AudioSource alertAudio;

   
    public SpriteRenderer backgroundSprite;
    public Color normalBackgroundColor = Color.white;
    public Color stealthBackgroundColor = new Color(0.3f, 0.3f, 0.3f);
    public Color alertBackgroundColor = new Color(0.8f, 0.2f, 0.2f);

    private float currentSpeed;
    private Coroutine flashRoutine;

    private GameState lastState;

    void Start()
    {
        currentSpeed=normalSpeed;
    }

    void Update()
    {
       
        GameState current = StateManager.Instance.currentState;

        if (current != lastState)
        {
            ApplyState(current);
            lastState = current;
        }
    }
    void OnEnable()
    {
        GameState current = StateManager.Instance.currentState;
        ApplyState(current);
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

            

            AudioManager.Instance.PlayBackground();
            if (backgroundSprite != null)
                backgroundSprite.color = normalBackgroundColor;
        }

       
        else if (state == GameState.Stealth)
        {
            currentSpeed = stealthSpeed;
            AudioManager.Instance.PlayBackground();
            if (backgroundSprite != null)
                backgroundSprite.color = stealthBackgroundColor;
        }

       
        else if (state == GameState.Alert)
        {
            currentSpeed = alertSpeed;
            AudioManager.Instance.PlayAlert();
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