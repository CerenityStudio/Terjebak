using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    private float dirX;
    private bool facingRight = true, isGrounded;

    private Vector3 localScale;
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 700f);
            anim.SetTrigger("Jump");
            isGrounded = false;
            SoundManager.instance.PlayerJumpSFX();
            Debug.Log("Lompat!");
        }

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        anim.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }

        else if (dirX < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && localScale.x < 0) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
