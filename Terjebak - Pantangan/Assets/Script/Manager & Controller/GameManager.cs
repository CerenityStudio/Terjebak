using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ScriptableInteger coins;
    public ScriptableInteger keys;
    
    public GameObject door;

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
        Debug.Log("Dev Mode Debug! 1. PlayerTakeDamage, 2. EnemyTakeDamage, 3. KuntilanakRangeAttack");
    }

    void Start()
    {
        door.SetActive(false);
    }

    void Update()
    {
        OpenDoor();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuUI.instance.PauseGame();
        }
    }

    internal void StartGame()
    {
        Time.timeScale = 1f;
    }

    internal void Retry()
    {
        coins.reset();
        keys.reset();
        Time.timeScale = 1f;
        SceneManager.LoadScene("_Main Scene");
    }

    internal void PauseGame()
    {
        Time.timeScale = 0f;
    }

    internal void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    internal void GameComplete()
    {
        StartCoroutine(GameCompletes());
    }

    private void OpenDoor()
    {
        if (keys.value == 4)
        {
            door.SetActive(true);
            //Debug.Log("Door Open");
        }
    }

    IEnumerator GameCompletes()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Ending Scene");
    }
}
