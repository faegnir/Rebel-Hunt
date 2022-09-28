using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    float angle;
    public static bool tapped = false;
    public static bool audioControl1 = false;
    public static bool audioControl2 = false;
    public static int sayac = 5;
    public static float fireAngle;
    bool stop = false;
    void Start()
    {
        audioControl2 = true;
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && stop == false && targets.isStill == false && (shoot.fireControl1 == false || shoot.fireControl2 == true))
        {
            firlatma();
        }
        else if (shoot.fireControl3 == true)
        {
            tapped = false;
            stop = false;
        }
        if (!stop)
        {
            rotateInd();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.Find("music") != null)
            {
                if (GameObject.Find("music").GetComponent<AudioSource>().isPlaying == false)
                {
                    audioControl1 = false;
                }
                else
                    audioControl1 = true;
                Destroy(GameObject.Find("music"));
            }
            SceneManager.LoadScene(0);
        }

    }
    void rotateInd()
    {
        angle = transform.rotation.eulerAngles.z;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, 120) - 60);
       /* float angle = Mathf.Sin(Time.time) * 70; //tweak this to change frequency
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
    }
    void firlatma()
    {
        if(mainmenu.audioa==true)
        GameObject.Find("Fire").GetComponent<AudioSource>().Play();
        tapped = true;
        fireAngle = angle;

        if (sayac > 0)
        {
            sayac--;
        }
        else
        {
            sayac = 6; sayac--;
            for (int i = 0; i <= 6; i++)
                GameObject.Find("Targets").transform.GetChild(i).position = new Vector2(-10, 6);
        }
    }
}
