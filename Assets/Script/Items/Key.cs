using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public ScriptableInteger key;

    public void OnGain()
    {
        key.value += 1;
    }
}
