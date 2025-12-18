using UnityEngine;

public class Batman : MonoBehaviour
{
    public float runMultiplier = 2f;

    private SpriteRenderer sr;
    public characterstate stateReceiver;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        float speed = stateReceiver.GetSpeed();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= runMultiplier;
        }

        Vector2 movement = new Vector2(moveX, moveY);
        transform.Translate(movement * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -1.5f, 4f);
        transform.position = pos;

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