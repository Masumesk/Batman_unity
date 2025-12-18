using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject batman;
    public GameObject Batmobil;

   

    void Start()
    {
        batman.SetActive(true);
        Batmobil.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isBatmanActive = batman.activeSelf;

            GameObject current = isBatmanActive ? batman : Batmobil;
            GameObject next = isBatmanActive ? Batmobil : batman;

           
            Vector3 newPos = next.transform.position;
            newPos.x = current.transform.position.x;

            

            next.transform.position = newPos;

            
            SpriteRenderer currentSR = current.GetComponent<SpriteRenderer>();
            SpriteRenderer nextSR = next.GetComponent<SpriteRenderer>();

            if (currentSR != null && nextSR != null)
                nextSR.flipX = currentSR.flipX;

            current.SetActive(false);
            next.SetActive(true);
        }
    }
}