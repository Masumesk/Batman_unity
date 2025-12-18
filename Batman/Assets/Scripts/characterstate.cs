using UnityEngine;
using System.Collections;


public class characterstate : MonoBehaviour
{
    [SerializeField]
    private float normalSpeed = 5f;
    [SerializeField]
    private float stealthSpeed = 2f;
    [SerializeField]
    private float alertSpeed = 7f;

    private float currentSpeed;

    private GameState lastState;

    void Start()
    {
        //در شروع در استیت نرمال هستیم
        currentSpeed=normalSpeed;
    }

    void Update()
    {
        
        GameState current = StateManager.Instance.currentState;
        //اگر استیت تغییر کنه باید تابع مربوط اجرا بشه
        if (current != lastState)
        {
            ApplyState(current);
            lastState = current;
        }
    }
    //وقتی یکی از بتمن یا بتموبیل فعال میشه باید طبق استیت تابع را اجرا کنه
    void OnEnable()
    {
        GameState current = StateManager.Instance.currentState;
        ApplyState(current);
    }

    //برای مشخص کردن سرعت در اسکریپت بتمن و بتموبیل
    public float GetSpeed()
    {
        return currentSpeed;
    }

    void ApplyState(GameState state)
    {

        //اگر وارد استیت نرمال شویم رنگ محیط و سرعت و صدای در حال پخش باید به حالت نرمال برگردد
        if (state == GameState.Normal)
        {
            currentSpeed = normalSpeed;
            AudioManager.Instance.PlayBackground();
        }
        //برای حالت مخفی کاری  سرعت  کمتر است
        else if (state == GameState.Stealth)
        {
            currentSpeed = stealthSpeed;
            AudioManager.Instance.PlayBackground();
        }

       //برای حالت هشدار سرعت بیشتر است صدا صدای هشدار است 
        else if (state == GameState.Alert)
        {
            currentSpeed = alertSpeed;
            AudioManager.Instance.PlayAlert();
        }
    }
}