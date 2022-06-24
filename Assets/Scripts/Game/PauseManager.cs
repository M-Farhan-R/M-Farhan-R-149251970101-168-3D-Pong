using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject pausePanel, gameOverPanel;


    void Update()
    {
        if (!gameOverPanel.activeInHierarchy)
        {
            if (!pausePanel.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseButton();
                }
            } else
            if (pausePanel.activeInHierarchy)
            {
                
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ResumeButton();
                }
            }
        } else
        {
            
        }
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        gameManager.ResetGame();
        ResumeButton();
    }

    public void ResumeButton()
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        if (gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
