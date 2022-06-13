using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Editor Windows Setting/Dev Mode")]
    [SerializeField] private float playerSpeed; 
    
    [Header("Android Setting")]
    [SerializeField] private float moveSpeed;
    private bool moveLeft, moveRight, isGrounded;
    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        moveLeft = false;
        moveRight = false;
    }

    void Update()
    {
//#if UNITY_EDITOR_WIN
//        float horizontal_input = Input.GetAxis("Horizontal");
//        rb.velocity = new Vector2(horizontal_input * playerSpeed, rb.velocity.y);

//        if (horizontal_input > 0.01f)
//        {
//            anim.SetBool("isRunning", true);
//            transform.localScale = Vector3.one;
//        }
//        else if (horizontal_input < -0.01f)
//        {
//            anim.SetBool("isRunning", true);
//            transform.localScale = new Vector3(-1, 1, 1);
//        }

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            Jump();
//        }
//#endif

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
            Debug.Log("Lompat!");
            rb.AddForce(Vector2.up * 700f);
            anim.SetTrigger("Jump");
            SoundManager.instance.PlayerJumpSFX();
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
