using UnityEngine;

public class Batmobil : MonoBehaviour
{
    public float speed = 7f;          
    public float runMultiplier = 2f; 

    private SpriteRenderer sr;

    private float leftLimit;
    private float rightLimit;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

       
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        leftLimit = -halfWidth - 1f;
        rightLimit = halfWidth + 1f;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = 0f;   

       
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= runMultiplier;
        }

       
        Vector2 movement = new Vector2(moveX, moveY);
        transform.Translate(movement * currentSpeed * Time.deltaTime);

        
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -1.5f, 4f);
        transform.position = pos;

        
        if (moveX > 0)
            sr.flipX = true;  
        else if (moveX < 0)
            sr.flipX = false;  

        WrapAround();
    }

    void WrapAround()
    {
        Vector3 pos = transform.position;

        if (pos.x > rightLimit)
            pos.x = leftLimit;
        else if (pos.x < leftLimit)
            pos.x = rightLimit;

        transform.position = pos;
    }
}