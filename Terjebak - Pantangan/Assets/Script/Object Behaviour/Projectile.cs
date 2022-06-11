using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed, damage;
    private float direction, projectile_lifetime;
    private bool hit;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        projectile_lifetime += Time.deltaTime;
        if (projectile_lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit by batu!");
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Hit by batu!");
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Batu destroyed!");
            anim.SetTrigger("Shattered");
            //Destroy(gameObject);
        }
    }

    public void SetDirection (float projectile_direction)
    {
        projectile_lifetime = 5;
        direction = projectile_direction;

        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != projectile_direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactive()
    {
        gameObject.SetActive(false);
    }
}
