using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Integer", menuName = "Scriptable Variable/Integer")]
public class ScriptableInteger : ScriptableObject
{
    public int value, defaultValue;
    public bool resetOnEnable;

    public void OnEnable()
    {
        if (resetOnEnable)
        {
            reset();
        }
    }

    internal void reset()
    {
        value = defaultValue;
    }
}
