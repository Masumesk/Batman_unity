using UnityEngine;

public class Batsignal : MonoBehaviour
{
    public SpriteRenderer sr;

    [SerializeField]
    private float moveSpeed = 2f;  

    [SerializeField]  
    private float rotateSpeed = 20f;   

    private bool isOn = false;

    private Vector2 direction;

    void Start()
    {
        if (sr != null)
        {
            sr.enabled = false;
        }
        //جهت تصادفی برای حرکت سیگنال
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {

        //if B is clicked batsignal is enabled
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOn = !isOn;
            if (sr != null)
            {
                sr.enabled = isOn;
            }
        }
        //اگر سیگنال فعال نشود نباید هیچ حرکتی داشته باشد
        if (!isOn)
        {
            return;
        }
        
        //چرخش خود سیگنال
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        //جا به جایی سیگنال در صحنه
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        Vector3 pos = transform.position;

        //سیگنال نباید از محدوده خارج شود
        if (pos.y > 4f)
        {
            pos.y = 4f;
            direction.y = -direction.y; 
        }
        else if (pos.y < 1.8f)
        {
            pos.y = 1.8f;
            direction.y = -direction.y;
        }
        if (pos.x > 7.5f)
        {
            pos.x = 7.5f;
            direction.x = -direction.x; 
        }
        else if (pos.x < -7.5f)
        {
            pos.x = -7.5f;
            direction.x = -direction.x; 
        }

        transform.position = pos;
    }
}