using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        var toggle = GameObject.Find("Toggle").GetComponent<UnityEngine.UI.Toggle>();
        var mus = GameObject.Find("music").GetComponent<AudioSource>();
        
        if (rotate.audioControl1 == true)
            mus.Play();
        else
            toggle.isOn = false;
        
        
        if (rotate.audioControl2 == false)
        {
            mus.Play();
            toggle.isOn = true;
        }
        DontDestroyOnLoad(GameObject.Find("music"));
    }
    void FixedUpdate()
    {
        if (PlayerPrefs.HasKey("level2")){
            GameObject.Find("level2").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("level2").GetComponent<Button>().interactable = false;
            GameObject.Find("imgL2").GetComponent<Image>().color = new Color32(255, 255, 255, 140);
        }
        if (PlayerPrefs.HasKey("level3"))
        {
            GameObject.Find("level3").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("level3").GetComponent<Button>().interactable = false;
            GameObject.Find("imgL3").GetComponent<Image>().color = new Color32(255, 255, 255, 140);
        }
        if (PlayerPrefs.HasKey("level4"))
        {
            GameObject.Find("level4").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("level4").GetComponent<Button>().interactable = false;
            GameObject.Find("imgL4").GetComponent<Image>().color = new Color32(255, 255, 255, 140);
        }

    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void level1()
    {
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        SceneManager.LoadScene(2);
    }
    public void level3()
    {
        SceneManager.LoadScene(3);
    }
    public void level4()
    {
        SceneManager.LoadScene(4);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    public void muteToggle(bool muted)
    {
        if (!muted)
        {
            GameObject.Find("music").GetComponent<AudioSource>().Pause();
        }
        else
        {
            GameObject.Find("music").GetComponent<AudioSource>().Play();
        }
    }
}
