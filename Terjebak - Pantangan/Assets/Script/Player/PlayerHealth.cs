using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        currHealth = startingHealth;
        anim = GetComponent<Animator>();
        Debug.Log("Current Health: " + currHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
            Debug.Log("DevMode: Press E for Taking Damage!");
        }
    }

    public void TakeDamage(float _damage)
    {
        /* menentukan max dan min
        min 0 max health awal */
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);

        if (currHealth > 0)
        {
            hurtSfx();
            //currHealth -= _damage;
            anim.SetTrigger("isStun");
        }
        else
        {
            //UIManager.instance.GameOver();
            //darah habis
            anim.SetTrigger("isDie");
            GetComponent<PlayerController>().enabled = false;
        }
    }

    public void AddHealth(float _value)
    {
        currHealth = Mathf.Clamp(currHealth + _value, 0, startingHealth);
    }

    public void hurtSfx()
    {
        //SoundManager.instance.playHurtSfx();
    }
}
