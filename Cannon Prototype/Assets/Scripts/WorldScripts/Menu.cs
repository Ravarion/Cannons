﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject mainMenu;
    public bool paused;

    void Start()
    {
        paused = false;
    }

    void Update()
    {
        if (paused && (Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.Escape)))
        {
            Pause();
        }
    }

    public void Pause()
    {
        //pause
        if (paused == false)
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
            //if the current cannon is the main cannon then effect that one
            foreach (GameObject mainCannon in GameObject.FindGameObjectsWithTag("MainCannon"))
            {

                if (mainCannon.GetComponent<PlayerController>().currentCannon == true)
                {
                    mainCannon.GetComponent<MouseLook>().enabled = false;
                    mainCannon.transform.FindChild("Barrel").GetComponent<MouseLook>().enabled = false;
                    mainCannon.GetComponent<PlayerController>().enabled = false;
                }
            }
            //if the current cannon is a subcannon cannon then effect that one
            foreach (GameObject cannon in GameObject.FindGameObjectsWithTag("Cannon"))
            {

                if (cannon.GetComponent<PlayerController>().currentCannon == true)
                {
                    cannon.GetComponent<MouseLook>().enabled = false;
                    cannon.GetComponent<PlayerController>().enabled = false;
                }
            }
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //unpause
        else if (paused == true)
        {
            Time.timeScale = 1;
            mainMenu.SetActive(false);
            foreach (GameObject mainCannon in GameObject.FindGameObjectsWithTag("MainCannon"))
            {

                if (mainCannon.GetComponent<PlayerController>().currentCannon == true)
                {
                    mainCannon.GetComponent<MouseLook>().enabled = true;
                    mainCannon.transform.FindChild("Barrel").GetComponent<MouseLook>().enabled = true;
                    mainCannon.GetComponent<PlayerController>().enabled = true;
                }
            }
            foreach (GameObject cannon in GameObject.FindGameObjectsWithTag("Cannon"))
            {

                if (cannon.GetComponent<PlayerController>().currentCannon == true)
                {
                    cannon.GetComponent<MouseLook>().enabled = true;
                    cannon.GetComponent<PlayerController>().enabled = true;
                }
            }
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        foreach (GameObject mainCannon in GameObject.FindGameObjectsWithTag("MainCannon"))
        {
            if (mainCannon.GetComponent<PlayerController>().currentCannon == true)
            {
                mainCannon.GetComponent<MouseLook>().enabled = true;
                mainCannon.GetComponent<PlayerController>().enabled = true;
            }
        }
        foreach (GameObject cannon in GameObject.FindGameObjectsWithTag("Cannon"))
        {

            if (cannon.GetComponent<PlayerController>().currentCannon == true)
            {
                cannon.GetComponent<MouseLook>().enabled = true;
                cannon.GetComponent<PlayerController>().enabled = true;
            }
        }        
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void MainMenuButton()
    {
        Time.timeScale = 1;
        paused = false;
        paused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Main Menu");
    }
    public void RestartLevelButton()
    {
        Time.timeScale = 1;
        paused = false;
        GetComponent<LevelManager>().ResetLevel();
    }
}
