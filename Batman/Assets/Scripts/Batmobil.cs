using UnityEngine;

public class Batmobil : MonoBehaviour
{
    [SerializeField]
    private float boost = 2f;

    private SpriteRenderer sr;

    [SerializeField]
    private characterstate stateReceiver;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Vector3 pos = transform.position;
        pos.y = -1.5f;
        transform.position = pos;
    }

    void Update()
    {
        //inputs
        float moveX = Input.GetAxisRaw("Horizontal");
        float speed = stateReceiver.GetSpeed();

        //boost
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= boost;
        }

        //move
        Vector2 movement = new Vector2(moveX, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        //ماشین فقط روی سطح زمین یعنی محور x حرکت میکند
        Vector3 pos = transform.position;
        pos.y = -1.5f;
        transform.position = pos;

        //نمایش تصویر ماشین با توجه به جهت حرکت
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

    //نمایش از سمت دیگر در صورت خروج از محدوده
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