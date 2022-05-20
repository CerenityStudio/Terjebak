using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coinss = 0;

    [SerializeField] private Text coinssText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            coinss++;
            coinssText.text = "Coins: " + coinss;
            collectionSoundEffect.Play();
        }
    }
}
