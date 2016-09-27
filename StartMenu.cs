using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour {
    
    public void StartButton() {
        SceneManager.LoadScene(1);
    }/*
    public void OptionsButton() {
        SceneManager.LoadScene(optionsScene);
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene(creditsScene);
    }
    public void TutorialButton()
    {
        SceneManager.LoadScene(tutorialScene);
    }*/
    public void QuitButton() {
        Application.Quit();
    }
}
