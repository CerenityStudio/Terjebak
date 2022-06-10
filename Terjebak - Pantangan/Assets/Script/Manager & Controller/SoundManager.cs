using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audios;

    [Header("Audio Clip SFX")]
    public AudioClip playerJump;
    public AudioClip playerDie;

    public AudioClip kuntilanakAttack;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        audios = GetComponent<AudioSource>();
    }

    public void PlayerJumpSFX()
    {
        audios.PlayOneShot(playerJump);
    }

    public void PlayerDeathSFX()
    {
        audios.PlayOneShot(playerDie);
    }

    public void KuntilanakAttackSFX()
    {
        audios.PlayOneShot(kuntilanakAttack);
    }
}
