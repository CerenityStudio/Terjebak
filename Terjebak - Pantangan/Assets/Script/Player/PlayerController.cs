using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 140f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool moveLeft, moveRight, isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }

        anim.SetBool("isGrounded", isGrounded);
    }

    public void MoveLeft()
    {
        moveLeft = true;
        anim.SetBool("isRunning", true);
        gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }

    public void MoveRight()
    {
        moveRight = true;
        anim.SetBool("isRunning", true);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity = Vector2.zero;
        anim.SetBool("isRunning", false);
    }

    public void Jump()
    {
        if (rb.velocity.y == 0)
        {
            //Debug.Log("Lompat!");
            rb.AddForce(Vector2.up * 700f);
            //rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
            anim.SetTrigger("isJump");
            isGrounded = false;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
