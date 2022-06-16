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

    public GameObject timeOverPanel, timeOverScene1, timeOverScene2;

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

    private void Start()
    {
        DeactivePanel();
    }

    private void Update()
    {
#if UNITY_EDITOR_WIN
        if (Input.GetKeyDown(KeyCode.L))
        {
            TimeOver();
            Debug.Log("Time's Up! You Lose!");
        }
#endif
    }

    private void DeactivePanel()
    {
        hudCanvas.SetActive(false);
        mainMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverMenuPanel.SetActive(false);
        timeOverPanel.SetActive(false);
        timeOverScene1.SetActive(false);
        timeOverScene2.SetActive(false);
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
    }

    public void TimeOver()
    {
        hudCanvas.SetActive(false);
        StartCoroutine(TimesUp());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator TimesUp()
    {
        timeOverPanel.SetActive(true);
        timeOverScene1.SetActive(true);
        yield return new WaitForSeconds(5f);
        timeOverScene1.SetActive(false);
        timeOverScene2.SetActive(true);
    }
}
