using UnityEngine;
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
	void Update ()
    {
        //pause
        if (Input.GetKeyDown(KeyCode.T) && paused == false)
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
            //if the current cannon is the main cannon then effect that one
            foreach (GameObject mainCannon in GameObject.FindGameObjectsWithTag("MainCannon"))
            {

                if (mainCannon.GetComponent<PlayerController>().currentCannon == true)
                {
                    mainCannon.GetComponent<MouseLook>().enabled = false;
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
        else if (Input.GetKeyDown(KeyCode.T) && paused == true)
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
        SceneManager.LoadScene(0);
    }
}
