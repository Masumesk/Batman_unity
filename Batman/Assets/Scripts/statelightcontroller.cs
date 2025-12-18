using UnityEngine;
using System.Collections;

public class statelightcontroller : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer background;
    [SerializeField] 
    private SpriteRenderer lightObject;

    private Coroutine flashRoutine;
    private GameState lastState;

    void Update()
    {
        //فقط وقتی اجرا میشود که استیت تغییر کنئ
        GameState current = StateManager.Instance.currentState;

        if (current != lastState)
        {
            Changelight(current);
            lastState = current;
        }
    }

    void OnEnable()
    {
        //هربار فعال میشود اجرا ش.د
        if (StateManager.Instance != null)
        {
            Changelight(StateManager.Instance.currentState);
        }
    }

    void Changelight(GameState state)
    {
        //اگر استیت از استیت هشدار تغییر کرده باشد چراغ چشمک زن باید قطع بشه
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
            flashRoutine = null;
        }

        //رنگ معمول در حالت نرمال
        if (state == GameState.Normal)
        {
           background.color =Color.white;
           lightObject.color=Color.white;
        }
        //محیط تاریک در حالت مخفی کاری
        else if (state == GameState.Stealth)
        {
            background.color =new Color(0.3f, 0.3f, 0.3f);
            lightObject.color=new Color(0.3f, 0.3f, 0.3f);
        }
        //نور چشمک زن در حالت هشدار
        else if (state == GameState.Alert)
        {
            flashRoutine = StartCoroutine(FlashLight());
        }
    }


    //روتینی است که در حالت هشدار اجرا میشود 
    //نور محیط به صورت چشمک زن آبی و قرمز میشود
    //نور آبجکت در نظر گرفته شده برای چراغ به صورت چشمک زن قرمز و آبی میشه
    IEnumerator FlashLight()
    {
        while (true)
        {
            background.color =Color.blue;
            lightObject.color=Color.red;
            yield return new WaitForSeconds(0.2f);

            background.color =Color.red;
            lightObject.color=Color.blue;
            yield return new WaitForSeconds(0.2f);
        }
    }
}