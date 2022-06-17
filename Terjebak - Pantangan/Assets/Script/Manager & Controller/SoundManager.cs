using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audios;

    [Header("Audio Clip SFX")]
    //public AudioClip bgmGameplay;
    public AudioClip playerJump;
    public AudioClip playerDie;
    public AudioClip kuntilanakAttack;

    public GameObject mute, unmute;

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

    private void Start()
    {
        Deactivated();
    }

    private void Deactivated()
    {
        unmute.SetActive(true);
        mute.SetActive(false);
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

    public void Mute()
    {
        unmute.SetActive(false);
        mute.SetActive(true);
        AudioListener.pause = true;
    }

    public void Unmute()
    {
        mute.SetActive(false);
        unmute.SetActive(true);
        AudioListener.pause = false;
    }
}
