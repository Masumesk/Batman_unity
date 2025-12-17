using UnityEngine;

public class Batman : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer sr;

    private float leftpart;
    private float rightpart;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        leftpart = -halfWidth - 1f;   
        rightpart = halfWidth + 1f;
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
        if (move > 0)
        {
            sr.flipX = true;
        }
        else if (move < 0)
        {
            sr.flipX = false;
        }
        transformposition();
    }

    void transformposition()
    {
        Vector3 pos = transform.position;

        if (pos.x > rightpart)
        {
            pos.x = leftpart;
        }
        else if (pos.x < leftpart)
        {
            pos.x = rightpart;
        }
        transform.position = pos;
    }
}