using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3 : MonoBehaviour
{
    public float currentValue,minValue,maxValue;
    public static float downval =4;
    public int direction;
    bool secondCtrl, thirdCtrl, firstCtrl,artob;
    public static bool dval;
    int a;

    void Start()
    {
        a = 1;
        downval = 4;
        rotate.sayac = 5;
        shoot.currLevel = 0;
    }

    void Update()
    {
        targets.isStill = false;

        if (shoot.currLevel == 0)
        {
            shooted0();
        }
        else if (shoot.currLevel == 1)
        {
            shooted1();
        }
        else if (shoot.currLevel == 2)
        {
            shooted2();
        }
        else if (shoot.currLevel == 3)
        {
            shooted3();
        }
        else if (shoot.currLevel == 4)
        {
            shooted4();
        }
        else if (shoot.currLevel == 5)
        {
            shooted5();
        }
        else if (shoot.currLevel == 6)
        {
            shooted6();
        }
        else if (shoot.currLevel == 7)
        {
            nextscene();
        }
        if(rotate.sayac==0)
            targets.isStill = true;

        firstCtrl = secondCtrl = thirdCtrl = false;
    }
    void leftToRight()
    {
         currentValue += Time.deltaTime * direction;
         if (currentValue >= maxValue)
         {
             direction *= -1;        
             currentValue = maxValue;
         }
         else if (currentValue <= minValue) 
         {
             direction *= -1; 
             currentValue = minValue;
         }
    }
    void down()
    {
        downval -= Time.deltaTime * 1;
        if (downval < -1.5)
        {
            dval = true;
            StopCoroutine("delayer");
        }
        else
            dval = false;
    }
    IEnumerator delayer()
    {
        if (shoot.currLevel == 0)
        {
            yield return new WaitForSeconds(1+a);
            a = 0;
            firstCtrl = true;
        }
        else if (shoot.currLevel == 1)
        {
            yield return new WaitForSeconds(1);
            secondCtrl = true;
        }
        else if (shoot.currLevel == 2)
        {

            yield return new WaitForSeconds(1);
            thirdCtrl = true;
        }
        else if (shoot.currLevel == 4)
        {
            yield return new WaitForSeconds(1);
            secondCtrl = true;
        }
        else if (shoot.currLevel == 7)
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void shooted0()
    {
        
        for (int i = 1; i <= 6; i++)
            GameObject.Find("Targets").transform.GetChild(i).position = new Vector2(-10, 6);

        if (GameObject.Find("hedef").transform.position.y == 6)
            targets.isStill = true;
        if (downval > -1.5)
        {
            StartCoroutine("delayer");
            if (firstCtrl == true)
            {
                leftToRight();
                down();
                GameObject.Find("hedef").transform.position = new Vector2(currentValue, downval);
            }
        }
    }   
    void shooted1()
    {
        if (GameObject.Find("lilhedef").transform.position.y == 6)
        {
            targets.isStill = true;
            downval = 4;
        }
        StartCoroutine("delayer");
        if (secondCtrl == true)
        {
            leftToRight();
            down();
            GameObject.Find("lilhedef").transform.position = new Vector2(currentValue, downval);
        }

    }
    void shooted2()
    {
        if (GameObject.Find("hedef05").transform.position.y ==6 && GameObject.Find("hedef05-2").transform.position.y == 6)
        {
            targets.isStill = true;
            downval = 4;
        }
        StartCoroutine("delayer");
        if (thirdCtrl == true)
        {
            leftToRight();
            down();
            GameObject.Find("hedef05").transform.position = new Vector2(currentValue, downval);
            GameObject.Find("hedef05-2").transform.position = new Vector2(-currentValue, downval);
        }

    }
    void shooted3()
    {
        leftToRight();
            down();
        if (GameObject.Find("hedef05").transform.position.y == 6)// && GameObject.Find("hedef05-2").transform.position.y != 4)
            GameObject.Find("hedef05-2").transform.position = new Vector2(-currentValue, downval);
        else
            GameObject.Find("hedef05").transform.position = new Vector2(currentValue, downval);
    }
    void shooted4()
    {
        if (GameObject.Find("lil").transform.position.y == 6 && GameObject.Find("lil1").transform.position.y == 6 && GameObject.Find("lil2").transform.position.y == 6)
        { 
            targets.isStill = true;
            downval = 4;
        }
        StartCoroutine("delayer");
        if (secondCtrl == true)
        {
            leftToRight();
            down();
            GameObject.Find("lil").transform.position = new Vector2(currentValue, downval);
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, downval);
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, downval);
        }
    }
    void shooted5()
    {
        leftToRight();
        down();
        if (GameObject.Find("lil").transform.position.y == 6)
        {
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, downval);
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, downval);
        }
        else if (GameObject.Find("lil1").transform.position.y == 6)
        {
            GameObject.Find("lil").transform.position = new Vector2(currentValue, downval);
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, downval);
        }
        else
        {
            GameObject.Find("lil").transform.position = new Vector2(currentValue, downval);
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, downval);
        }
    }
    void shooted6()
    {
        leftToRight();
        down();
        if (GameObject.Find("lil").transform.position.y <5)
        {
            GameObject.Find("lil").transform.position = new Vector2(currentValue, downval);
        }
        else if (GameObject.Find("lil1").transform.position.y < 5)
        {
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, downval);
        }
        else
        {
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, downval);
        }
    }
    void nextscene()
    {
        PlayerPrefs.SetInt("level4", 4);
        GameObject.Find("Ship").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameObject.Find("Ship").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        GameObject.Find("Fire").gameObject.SetActive(false);

        StartCoroutine("delayer");
    }
}
