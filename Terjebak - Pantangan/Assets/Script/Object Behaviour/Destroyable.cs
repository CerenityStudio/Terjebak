using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
