using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    private Animator anim;

    void Awake()
    {
        currHealth = startingHealth;
        anim = GetComponent<Animator>();
        Debug.Log("Current Health: " + currHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(1);
            Debug.Log("DevMode: Press 1 for Player Taking Damage!");
        }
    }

    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);

        if (currHealth > 0)
        {
            //SoundManager.instance.playHurtSfx();
            anim.SetTrigger("Stun");
        }
        else
        {
            //UIManager.instance.GameOver();
            anim.SetTrigger("Die");
            GetComponent<PlayerController>().enabled = false;
        }
    }

    public void AddHealth(float _value)
    {
        currHealth = Mathf.Clamp(currHealth + _value, 0, startingHealth);
    }
}
