using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject mainMenuUI;
    public GameObject fade;
    public GameObject fadeBlack;
    public GameObject pauseMenuUI;


    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        mainMenuUI.SetActive(false);
        fade.SetActive(true);
        fadeBlack.SetActive(true);
        Time.timeScale = 1f;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        fade.SetActive(false);
        fadeBlack.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Level0");
    }
}
