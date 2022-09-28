using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class targets : MonoBehaviour
{
    public static bool isStill = false;
    bool secondControl,thirdControl,firstControl;
    int a;

    void Start()
    {
        a = 1;
        shoot.currLevel = 0;
        rotate.sayac = 5;
    }
    void Update()
    {
        isStill = false;

        if (shoot.currLevel == 0)
        {
            firstLevel();
        }
        else if (shoot.currLevel == 1)
        {
            secondLevel();
        }
        else if (shoot.currLevel == 2)
        {
            thirdLevel();
        }
        else if (shoot.currLevel == 4)
        {            
            fourthLevel();
        }
        else if (shoot.currLevel == 7)
        {
            nextscene();
        }

        keyConditions();
        firstControl = secondControl = thirdControl = false;
    }
    void firstLevel()
    {
        if (GameObject.Find("hedef").transform.position.y != 4)
            isStill = true;

        for (int i = 1; i <= 6; i++)
            GameObject.Find("Targets").transform.GetChild(i).position = new Vector2(-10, 6);

        StartCoroutine("delayer");
        if (firstControl == true)
        {
            GameObject.Find("hedef").transform.position = new Vector2(0, 4);
        }
    }
    void secondLevel()
    {
        if (GameObject.Find("lilhedef").transform.position.y != 4)
            isStill = true;
       
        StartCoroutine("delayer");
        if (secondControl == true)
        {
             GameObject.Find("lilhedef").transform.position = new Vector2(0, 4);
        }
    }
    void thirdLevel()
    {
        if (GameObject.Find("hedef05").transform.position.y != 4 && GameObject.Find("hedef05-2").transform.position.y != 4)
            isStill = true;

        StartCoroutine("delayer");
        if (thirdControl==true)
        {
            GameObject.Find("hedef05").transform.position = new Vector2(-3 / 2, 4);
            GameObject.Find("hedef05-2").transform.position = new Vector2(3 / 2, 4);
        }
    }
    void fourthLevel()
    {
        if (GameObject.Find("lil").transform.position.y != 4 && GameObject.Find("lil1").transform.position.y != 4 && GameObject.Find("lil2").transform.position.y != 4)
            isStill = true;

        StartCoroutine("delayer");
        if (secondControl == true)
        {
            GameObject.Find("lil").transform.position = new Vector2(-2, 4);
            GameObject.Find("lil2").transform.position = new Vector2(0, 4);
            GameObject.Find("lil1").transform.position = new Vector2(2, 4);
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
        else if(shoot.currLevel == 7)
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void keyConditions()
    {
        if (rotate.sayac == 0)
            isStill = true;
        
        if (rotate.sayac == 0 && GameObject.Find("hedef").GetComponent<SpriteRenderer>().enabled == false)
        {
            StopCoroutine("delayer");
            for (int i = 0; i <= 6; i++)
                GameObject.Find("Targets").transform.GetChild(i).position = new Vector2(-10, 6);
        }
    }
    void nextscene()
    {
        PlayerPrefs.SetInt("level2", 2);
        GameObject.Find("Ship").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameObject.Find("Ship").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        GameObject.Find("Fire").gameObject.SetActive(false);

        StartCoroutine("delayer");
    }
}
