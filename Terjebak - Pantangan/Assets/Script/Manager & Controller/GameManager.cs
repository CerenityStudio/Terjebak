using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    }

    internal void StartGame()
    {
        Time.timeScale = 1f;
    }

    internal void Retry()
    {
        coins.reset();
        keys.reset();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void OpenDoor()
    {
        if (keys.value == 4)
        {
            Debug.Log("Door Open");
            door.SetActive(true);
        }
    }
}
