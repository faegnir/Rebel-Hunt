using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class signs : MonoBehaviour
{
    void Start()
    {
        targets.isStill = true;
    }
    void Update()
    {
        if (GameObject.Find("Ship").GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
            targets.isStill = true;
        if (targets.isStill == true)
        {
            GameObject.Find("bolts").GetComponent<SpriteRenderer>().enabled = false;

            for (int i = 0; i < 5; i++)
                gameObject.transform.GetChild(i).position = new Vector2(4, 0);
        }
        else if (targets.isStill == false && rotate.sayac == 5)
        {
            GameObject.Find("bolts").GetComponent<SpriteRenderer>().enabled = true;

            for (int i = 0; i < rotate.sayac; i++)
                gameObject.transform.GetChild(i).position = new Vector2(1.52f + 0.17f * i, -4.75f);
        }
        if (rotate.sayac != 5)
            gameObject.transform.GetChild(rotate.sayac).position = new Vector2(4, 0);

        if (rotate.sayac != 0)
        {
            if (targets.isStill == true && level3.dval == false && level4.dval==false&& GameObject.Find("Ship").GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Dynamic)
            {
                GameObject.Find("readySign").GetComponent<SpriteRenderer>().enabled = true;
            }
            else
                GameObject.Find("readySign").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (shoot.currLevel == 7)
        {
            if (SceneManager.GetActiveScene().buildIndex > 2)
                GameObject.Find("Lightning").SetActive(false);

            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                GameObject.Find("wonSign").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("levelSign").GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                if (SceneManager.GetActiveScene().buildIndex == 2)
                    rotate.sayac = 5;
                GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("levelSign").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
       
        if (SceneManager.GetActiveScene().buildIndex < 3)
        retryfor2();
        else
        retry();
    }
    bool retwait = false;
    public void retryfor2()
    {
        if (rotate.sayac == 0)
        {
            StartCoroutine("retrynumerator");
            if (retwait == true)
            {
                if (GameObject.Find("Fire").transform.position.y == -3)
                {
                    targets.isStill = true;
                    GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = true;
                    for (int i = 0; i <= 6; i++)
                        GameObject.Find("Targets").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                    if (Input.GetMouseButtonDown(0))
                    {
                        shoot.currLevel = 0;
                        for (int i = 0; i <= 6; i++)
                            GameObject.Find("Targets").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                        rotate.sayac = 5;
                    }
                }
            }
            else
                GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            retwait = false;
            GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public static bool pressed = false;
    public void retry()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (level3.dval == true)
            {
                targets.isStill = true;
                GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hedef").transform.position = new Vector2(-10, 6);
                if (Input.GetMouseButtonDown(0))
                {
                    shoot.currLevel = 0;
                    for (int i = 0; i <= 6; i++)
                        GameObject.Find("Targets").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true; 
                    rotate.sayac = 5;
                    level3.downval = 4;
                    level3.dval = false;
                }
                else
                {
                    for (int i = 0; i <= 6; i++)
                        GameObject.Find("Targets").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
                GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (level4.dval == true)
            {
                targets.isStill = true;
                GameObject.Find("hedef").transform.position = new Vector2(-10, 6);
                GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = true;
                if (Input.GetMouseButtonDown(0))
                { 
                    shoot.currLevel = 0;
                    for (int i = 0; i <= 6; i++)
                        GameObject.Find("Targets").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                    rotate.sayac = 5;
                    level4.downval = 4;
                    pressed = false;
                    level4.dval = false;
                }
                else
                {
                    pressed = true;
                    for (int i = 0; i <= 6; i++)
                        GameObject.Find("Targets").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
                GameObject.Find("retry").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    IEnumerator retrynumerator()
    {
        yield return new WaitForSeconds(0.1f);
        retwait = true;
    }
}
