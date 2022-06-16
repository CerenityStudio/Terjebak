using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireTrap : MonoBehaviour
{
    private BoxCollider2D firecol;

    private void Awake()
    {
        firecol = GetComponent<BoxCollider2D>();
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
