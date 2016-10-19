using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour {

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void FirstLevel()
    {
        SceneManager.LoadScene("Pipes");
    }
    public void SecondLevel()
    {
        SceneManager.LoadScene("Jonathan_Glider_Level");
    }
    public void ThirdLevel()
    {
        SceneManager.LoadScene("Aram_Cavern_Lvl");
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
