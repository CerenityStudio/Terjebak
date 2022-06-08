using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Patrol : MonoBehaviour
{
    [HideInInspector] public bool mustPatrol;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;
    private bool mustFlip;
    private Animator anim;

    public float walkSpeed;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
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
        if (mustFlip || boxCol.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
