using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScriptableInteger keys;
    public GameObject door;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
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
