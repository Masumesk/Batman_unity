using UnityEngine;

public class Batmobil : MonoBehaviour
{
    public float runMultiplier = 2f;
    public float yposfixed = -1.5f;

    private SpriteRenderer sr;
    private float leftLimit;
    private float rightLimit;

    public characterstate stateReceiver;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        leftLimit = -halfWidth - 1f;
        rightLimit = halfWidth + 1f;

        Vector3 pos = transform.position;
        pos.y = yposfixed;
        transform.position = pos;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float speed = stateReceiver.GetSpeed();

        if (Input.GetKey(KeyCode.LeftShift))
            speed *= runMultiplier;

        Vector2 movement = new Vector2(moveX, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = yposfixed;
        transform.position = pos;

        if (moveX > 0)
            sr.flipX = true;
        else if (moveX < 0)
            sr.flipX = false;

        Wrap();
    }

    void Wrap()
    {
        Vector3 pos = transform.position;

        if (pos.x > rightLimit)
            pos.x = leftLimit;
        else if (pos.x < leftLimit)
            pos.x = rightLimit;

        pos.y = yposfixed;
        transform.position = pos;
    }
}