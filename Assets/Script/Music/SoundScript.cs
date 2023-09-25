using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    private Music music;
    public Button musicToggleButton;

    //public GameObject toggler;

    void Start () {
        music = GameObject.FindObjectOfType<Music>();
        UpdateIcon();
    }

    void Update (){

    }

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            //print (toggler.GetComponent<Toggle>().isOn);
            musicToggleButton.GetComponent<Toggle>().enabled = false;
        }
        else
        {
            AudioListener.volume = 0;
             musicToggleButton.GetComponent<Toggle>().enabled = true;
        }
    }
}
