using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public static float currLevel = 0;
    public static bool fireControl1 = false;
    public static bool fireControl2,fireControl3;// = false
    public GameObject explosionPrefab;
    public float atisHizi;

    void Update()
    {
        fireControl3 = false;
        if (rotate.tapped == true)
        {
            fired();
        }
        else
        {
            GetComponent<Rigidbody2D>().rotation = 0;
            transform.position = new Vector2(0, -3);
        }
    }
    void fired()
    {
        fireControl1 = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().rotation  = rotate.fireAngle;
        GetComponent<Rigidbody2D>().velocity = transform.up * atisHizi;

        if (Mathf.Abs(transform.position.x) > 3 || Mathf.Abs(transform.position.y) > 5.3)
            back(new Vector2(0, -3));
        else
            fireControl2 = false;
    }
    void OnCollisionEnter2D(Collision2D collision)//çarpýþma durumu
    {
        if(mainmenu.audioa==true)
        GameObject.Find("Ship").GetComponent<AudioSource>().Play();
        Vector3 yer = collision.transform.position;
        if (collision.gameObject.tag == ("hedef"))
        {
            if (rotate.sayac != 6 && currLevel != 2 && currLevel != 4 && currLevel != 5 &&currLevel != 6)
                rotate.sayac = 5;
            
            back(new Vector2(20, 0));

            collision.gameObject.transform.position = new Vector2(5, 6);
            Instantiate(explosionPrefab, yer, Quaternion.identity);
            currLevel++;
        }
        else
            fireControl2 = false;
    }
    void back(Vector2 vector2)
    {
        GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        transform.position = vector2;
        fireControl2 = true;
        fireControl3 = true;
    }
}
