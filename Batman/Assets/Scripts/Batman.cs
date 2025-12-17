using UnityEngine;

public class Batman : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

       
        if (move > 0)
            sr.flipX = true;   
        else if (move < 0)
            sr.flipX = false;    
    }
}