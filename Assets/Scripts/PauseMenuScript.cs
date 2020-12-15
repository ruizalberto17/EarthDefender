using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {
    public string MainMenu;
    public string LevelSelect;
    public bool IsPaused;
    public GameObject PauseMenuCanvas;

	// Update is called once per frame
	void Update () {

        if (IsPaused == true){
            PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else{
            PauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            IsPaused = true;
        }
    }

    public void Resume(){
        IsPaused = false;
    }
    public void MainMenuJump()
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene(LevelSelect);
    }
}
