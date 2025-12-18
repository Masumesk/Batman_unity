using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject batman;
    [SerializeField]
    private GameObject Batmobil;

   

    void Start()
    {
        //در شروع بازی بت من فعال است
        batman.SetActive(true);
        Batmobil.SetActive(false);
    }

    void Update()
    {
        //اگر کلید M زده شود باید 
        //کاراکتر ها به بت من یا بتموبیل تغییر کند
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isBatmanActive = batman.activeSelf;

            //طبق این که کدام فعال است بعدی مشخص میشود
            GameObject current = isBatmanActive ? batman : Batmobil;
            GameObject next = isBatmanActive ? Batmobil : batman;

            //game object
            //جدید باید در همان مکان 
            //object
            //قبلی نمایش داده بشه
            Vector3 newPos = next.transform.position;
            newPos.x = current.transform.position.x;
            next.transform.position = newPos;

            
            SpriteRenderer currentSR = current.GetComponent<SpriteRenderer>();
            SpriteRenderer nextSR = next.GetComponent<SpriteRenderer>();

            //طبق این که قبلی به کدام سمت حرکت میکرده آبجکت جدید هم باید به همان سمت نشون داده بشه
            if (currentSR != null && nextSR != null)
            {
                nextSR.flipX = currentSR.flipX;
            }

            current.SetActive(false);
            next.SetActive(true);
        }
    }
}