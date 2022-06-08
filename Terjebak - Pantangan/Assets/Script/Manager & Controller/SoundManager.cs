using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audios;

    [Header("Audio Clip SFX")]
    public AudioClip jump;
    public AudioClip playerDeath;

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

    public void JumpSFX()
    {
        audios.PlayOneShot(jump);
    }

    public void PlayerDeathSFX()
    {
        audios.PlayOneShot(playerDeath);
    }


}
