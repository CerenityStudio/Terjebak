using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Patrol : MonoBehaviour
{
    [HideInInspector] public bool mustPatrol;
    private bool mustFlip;
    private Animator anim;

    public float walkSpeed;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("isMoving", false);
    }

    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustFlip)
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        //anim.SetBool("isMoving", true);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
