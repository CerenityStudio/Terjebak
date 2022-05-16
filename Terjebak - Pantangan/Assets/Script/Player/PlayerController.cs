using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float playerSpeed;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //body.velocity = new Vector2;
    }

    public void MoveRight()
    {
        transform.localScale = Vector3.one;
    }

    public void MoveLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, playerSpeed);
        //anim.SetTrigger("isJump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
