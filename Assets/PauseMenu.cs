using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    //private int SceneLoad;
    // Update is called once per frame
    
    void Start() {
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        // if (Time.timeScale == 0)
        // {
        //     Cursor.visible = true;
        // }
        // if (Time.timeScale >= 1)
        // {
        //     Cursor.visible = false;
        // }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {

                //Cursor.visible = false;
                Resume();
            }
            else
            {
                //Cursor.visible = true;
                Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.visible = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // public void LoadMenu(string scenename)
    // {
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene(scenename);
    //     GameIsPaused = false;
    //     Cursor.visible = true;
    // }

    // public void Retry(string scenename)
    // {
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene(scenename);
    //     GameIsPaused = false;
    // }

    // public void QuitGame()
    // {
    //     // Debug.Log("Quitting game...");
    //     Application.Quit();
    // }
}
