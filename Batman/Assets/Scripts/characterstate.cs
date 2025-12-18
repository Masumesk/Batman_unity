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

    [SerializeField]
    private SpriteRenderer lightobject;
    [SerializeField]
   
    private SpriteRenderer sr;

    private float currentSpeed;
    private Coroutine flashRoutine;

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

       //وقتی از حالت هشدار وارد یک حالت جدید میشویم روتین چشمک زدن باید غیر فعال بشه
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
            flashRoutine = null;
        }
        //اگر وارد استیت نرمال شویم رنگ محیط و سرعت و صدای در حال پخش باید به حالت نرمال برگردد
        if (state == GameState.Normal)
        {
            currentSpeed = normalSpeed;
            AudioManager.Instance.PlayBackground();
            if (sr != null)
            {
                sr.color = Color.white;
                lightobject.color=Color.white;
            }
        }
        //برای حالت مخفی کاری نور محیط تاریک میشود و سرعت هم کمتر است
        else if (state == GameState.Stealth)
        {
            currentSpeed = stealthSpeed;
            AudioManager.Instance.PlayBackground();
            if (sr != null)
            {
                sr.color =  new Color(0.3f, 0.3f, 0.3f);
                lightobject.color= new Color(0.3f, 0.3f, 0.3f);
            }
        }

       //برای حالت هشدار سرعت بیشتر است صدا صدای هشدار است و نور های چشمک زن فعال است
        else if (state == GameState.Alert)
        {
            currentSpeed = alertSpeed;
            AudioManager.Instance.PlayAlert();
            flashRoutine=StartCoroutine(FlashLight());
        }
    }


    //روتین چراغ چشمک زن است صحنه بازی را به صورت چشمک زن آبی و قرمز میکند و همزمان با آن یک
    //object
    //دیگر که برای چراغ در نظر گرفته شده است را قرمز و آبی میکند
    IEnumerator FlashLight()
    {
        while (true)
        {
            
            sr.color = Color.blue;
            lightobject.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.red;
            lightobject.color =  Color.blue;
            yield return new WaitForSeconds(0.2f);
        }
    }
}