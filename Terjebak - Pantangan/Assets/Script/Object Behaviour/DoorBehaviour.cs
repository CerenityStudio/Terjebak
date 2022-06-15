using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public void OnEnter()
    {
        GameManager.instance.GameComplete();
    }
}
