using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string StartGame;
    public string Settings;
    public string LevelSelect;
    public string Credits;

    public void Play() {
        SceneManager.LoadScene(StartGame);
    }
    public void SettingsMenu(){
        SceneManager.LoadScene(Settings);
    }

    public void SelectLevel(){
        SceneManager.LoadScene(LevelSelect);
    }

    public void CreditsLevel()
    {
        SceneManager.LoadScene(Credits);
    }

    public void Quit() {
        Application.Quit();
    }
}
