using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2 : MonoBehaviour
{
    public float currentValue,minValue,maxValue;
    public int direction;
    bool secondControl, thirdControl, firstControl;
    int a;

    void Start()
    {
        a = 1;
        rotate.sayac = 5;
        shoot.currLevel = 0;
    }
    void Update()
    {
        targets.isStill = false;
        if (shoot.currLevel == 0)
        {
            a0();
        }
        else if (shoot.currLevel == 1)
        {
            a1();
        }
        else if (shoot.currLevel == 2)
        {
            a2();
        }
        else if (shoot.currLevel == 3)
        {
            a3();
        }
        else if (shoot.currLevel == 4)
        {
            a4();
        }
        else if (shoot.currLevel == 5)
        {
            a5();
        }
        else if (shoot.currLevel == 6)
        {
            a6();
        }
        else if (shoot.currLevel == 7)
        {
            nextscene();
        }
        keyConditions();
        firstControl = secondControl = thirdControl = false;
    }
    void leftToRight()
    {

        currentValue += Time.deltaTime * direction; // imlecin pozisyonuna ekler
        if (currentValue >= maxValue) //eger imlec en sað sýnýrýn pozisyonundan büyükse
        {
            direction *= -1;        //directionu sola cevirir
            currentValue = maxValue;
        }
        else if (currentValue <= minValue) //imlec left borderdan daha sola gelirse
        {
            direction *= -1; //direction saga cevrilir
            currentValue = minValue;
        }
    }
    IEnumerator delayer()
    {
        if (shoot.currLevel == 0)
        {
            yield return new WaitForSeconds(1+a);
            a = 0;
            firstControl = true;
        }
        else if (shoot.currLevel == 1 || shoot.currLevel == 4)
        {
            yield return new WaitForSeconds(1);
            secondControl = true;
        }
        else if (shoot.currLevel == 2)
        {

            yield return new WaitForSeconds(1);
            thirdControl = true;
        }
        else if (shoot.currLevel == 7)
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void a0()
    {
        if (GameObject.Find("hedef").transform.position.y != 4)
        {
            targets.isStill = true;
            currentValue = 0;
        }

        StartCoroutine("delayer");
        if (firstControl == true)
        {
            leftToRight();
            GameObject.Find("hedef").transform.position = new Vector2(currentValue, 4);
        }
    }
    void a5()
    {
        leftToRight();
        if (GameObject.Find("lil").transform.position.y != 4)
        {
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, 4);
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, 4);
        }
        else if (GameObject.Find("lil1").transform.position.y != 4)
        {
            GameObject.Find("lil").transform.position = new Vector2(currentValue, 4);
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, 4);
        }
        else
        {
            GameObject.Find("lil").transform.position = new Vector2(currentValue, 4);
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, 4);
        }
    }
    void a6()
    {
        leftToRight();
        if (GameObject.Find("lil").transform.position.y == 4)
        {
            GameObject.Find("lil").transform.position = new Vector2(currentValue, 4);
        }
        else if (GameObject.Find("lil1").transform.position.y == 4)
        {
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, 4);
        }
        else
        {
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, 4);
        }
    }
    void a3()
    {
        leftToRight();
        if (GameObject.Find("hedef05").transform.position.y == 4)
            GameObject.Find("hedef05").transform.position = new Vector2(currentValue, 4);
        else
            GameObject.Find("hedef05-2").transform.position = new Vector2(-currentValue, 4);
    }
    void a1()
    {
        if (GameObject.Find("lilhedef").transform.position.y != 4)
            targets.isStill = true;

        StartCoroutine("delayer");
        if (secondControl == true)
        {
            leftToRight();
            GameObject.Find("lilhedef").transform.position = new Vector2(currentValue, 4);
        }

    }
    void a2()
    {
        if (GameObject.Find("hedef05").transform.position.y != 4 && GameObject.Find("hedef05-2").transform.position.y != 4)
            targets.isStill = true;

        StartCoroutine("delayer");
        if (thirdControl == true)
        {
            leftToRight();
            GameObject.Find("hedef05").transform.position = new Vector2(currentValue, 4);
            GameObject.Find("hedef05-2").transform.position = new Vector2(-currentValue, 4);
        }

    }
    void a4()
    {
        if (GameObject.Find("lil").transform.position.y != 4 && GameObject.Find("lil1").transform.position.y != 4 && GameObject.Find("lil2").transform.position.y != 4)
            targets.isStill = true;

        StartCoroutine("delayer");
        if (secondControl == true)
        {
            leftToRight();
            GameObject.Find("lil").transform.position = new Vector2(currentValue, 4);
            GameObject.Find("lil2").transform.position = new Vector2(Mathf.Sin(currentValue) * 2.35f, 4);
            GameObject.Find("lil1").transform.position = new Vector2(-currentValue, 4);
        }
    }
    void keyConditions()
    {
        if (rotate.sayac == 0)
            targets.isStill = true;
        
        if (rotate.sayac == 0 && GameObject.Find("hedef").GetComponent<SpriteRenderer>().enabled == false)
        {
            StopCoroutine("delayer");
            for (int i = 0; i <= 6; i++)
                GameObject.Find("Targets").transform.GetChild(i).position = new Vector2(-10, 6);
        }
    }
    void nextscene()
    {
        PlayerPrefs.SetInt("level3", 3);
        GameObject.Find("Ship").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameObject.Find("Ship").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        GameObject.Find("Fire").gameObject.SetActive(false);

        StartCoroutine("delayer");
    }
}
