using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public GameObject dieParticleEffect;
    
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            DestroyBullet();
            Debug.Log("Tidak kena!");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4f);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (dieParticleEffect != null)
        {
            Instantiate(dieParticleEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
