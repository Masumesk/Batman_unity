using UnityEngine;

public class Batman : MonoBehaviour
{
    [SerializeField]
    private float boost = 2f;

    private SpriteRenderer sr;
    
    [SerializeField]
    private characterstate stateReceiver;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        //inputs
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        float speed = stateReceiver.GetSpeed();

        //سرعت بیشتر در صورت نگه داشتن shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= boost;
        }

        //حرکت
        Vector2 movement = new Vector2(moveX, moveY);
        transform.Translate(movement * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        //محدود کردن محدوده حرکت عمودی
        pos.y = Mathf.Clamp(pos.y, -1.5f, 4f);
        transform.position = pos;

        //طبق این که متحرک به کدام سمت حرکت میکند جهت تصویر بت من به همان سمت مشخص شود
        if (moveX > 0)
        {
            sr.flipX = true;
        }
        else if (moveX < 0)
        {
            sr.flipX = false;
        }

        Wrap();
    }

    //خارج نشدن بتمن از صفحه در صورت خروج از جپ از سمت راست نمایش داده میشود و برعکس ..
    void Wrap()
    {
        Vector3 pos = transform.position;

        if (pos.x > 10.13f)
        {
            pos.x = -9.7f;
        }
        else if (pos.x < -9.7f)
        {
            pos.x = 10.13f;
        }

        transform.position = pos;
    }
}