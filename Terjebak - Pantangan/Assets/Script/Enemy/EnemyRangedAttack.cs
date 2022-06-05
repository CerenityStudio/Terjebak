using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerController playerController;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] nails;

    private EnemyHealth playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    public void RangedAttack()
    {
        anim.SetTrigger("RangedAttack");
        cooldownTimer = 0;

        nails[CheckNail()].transform.position = firePoint.position;

        nails[CheckNail()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

        Debug.Log("Enemy attacking!");
    }

    private int CheckNail()
    {
        for (int i = 0; i < nails.Length; i++)
        {
            if (!nails[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
