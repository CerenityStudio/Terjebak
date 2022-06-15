using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public static MenuUI instance;

    public GameObject hudCanvas;
    public GameObject mainMenuPanel;
    public GameObject pauseMenuPanel;
    public GameObject gameOverMenuPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        hudCanvas.SetActive(true);
        GameManager.instance.StartGame();
    }

    public void PauseGame()
    {
        hudCanvas.SetActive(false);
        pauseMenuPanel.SetActive(true);
        GameManager.instance.PauseGame();
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        hudCanvas.SetActive(true);
        GameManager.instance.ResumeGame();
    }

    public void GameOverPanel()
    {
        hudCanvas.SetActive(false);
        gameOverMenuPanel.SetActive(true);
    }

    public void RetryLevel()
    {
        gameOverMenuPanel.SetActive(false);
        hudCanvas.SetActive(true);
        GameManager.instance.Retry();
        SceneManager.LoadScene("_Main Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
