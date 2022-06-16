using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireTrap : MonoBehaviour
{
    Collider2D firecol;
    
    void Start()
    {
        firecol = this.GetComponent<Collider2D> ();
    }

    public void FireON()
    {
        firecol.enabled = true;
    }

    public void FireOFF()
    {
        firecol.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (other.gameObject);
    }
}
