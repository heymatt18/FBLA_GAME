using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour {

    public GameObject pauseScreen;
    public GameObject controlScreen;
    public GameObject resume;
    public GameObject controls;
    public GameObject quit;
    private int menuNum = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy == false)
            {
                Time.timeScale = 0f;
                pauseScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseScreen.SetActive(false);
            }
        }

        if (pauseScreen.activeInHierarchy == true || controlScreen.activeInHierarchy == true)
        pauseMenu();
    }

    public void pauseMenu()//controls processes inside the pause menu 
    {
        if (menuNum == 0)
            menuNum = 3;
        else if (menuNum == 1)
        {
            resume.GetComponent<Image>().color = new Color32(255, 244, 0, 210);
            controls.GetComponent<Image>().color = new Color32(0, 72, 171, 210); 
            quit.GetComponent<Image>().color = new Color32(0, 72, 171, 210); 

            if(Input.GetKeyDown(KeyCode.Return)) //unpauses game
            {
                Time.timeScale = 1f;
                pauseScreen.SetActive(false);
            }
        }
        else if (menuNum == 2)
        {
            controls.GetComponent<Image>().color = new Color32(255, 244, 0, 210);
            resume.GetComponent<Image>().color = new Color32(0, 72, 171, 210); 
            quit.GetComponent<Image>().color = new Color32(0, 72, 171, 210);
            if (controlScreen.activeInHierarchy == false) //triggers the control screen on and off
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    controlScreen.SetActive(true);
                    pauseScreen.SetActive(false);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return)) 
                {
                    controlScreen.SetActive(false);
                    pauseScreen.SetActive(true);
                }
            } 
        }
        else if (menuNum == 3)
        {
            quit.GetComponent<Image>().color = new Color32(255, 244, 0, 210); 
            resume.GetComponent<Image>().color = new Color32(0, 72, 171, 210); 
            controls.GetComponent<Image>().color = new Color32(0, 72, 171, 210);

            if (Input.GetKeyDown(KeyCode.KeypadEnter)) //quits game
                Application.Quit();
        }
        else if (menuNum == 4)
            menuNum = 1;

        if (Input.GetKeyDown(KeyCode.UpArrow)) 
            menuNum--;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            menuNum++;
    }
}
