using UnityEngine;

public class Batsignal : MonoBehaviour
{
    public SpriteRenderer signalSprite;

    public float moveSpeed = 2f;      
    public float rotateSpeed = 20f;   

    private bool isOn = false;

    private float minY = 1.8f;
    private float maxY = 4f;

    private float minX=-7.5f;
    private float maxX=7.5f;

    private Vector2 direction;

    void Start()
    {
        if (signalSprite != null)
            signalSprite.enabled = false;

        
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOn = !isOn;
            if (signalSprite != null)
                signalSprite.enabled = isOn;
        }

        if (!isOn)
            return;

        
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        Vector3 pos = transform.position;

        
        if (pos.y > maxY)
        {
            pos.y = maxY;
            direction.y = -direction.y; 
        }
        else if (pos.y < minY)
        {
            pos.y = minY;
            direction.y = -direction.y;
        }

        
        if (pos.x > maxX)
        {
            pos.x = maxX;
            direction.x = -direction.x; 
        }
        else if (pos.x < minX)
        {
            pos.x = minX;
            direction.x = -direction.x; 
        }

        transform.position = pos;
    }
}