using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] private float range, distanceCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject nail;
    
    [HideInInspector] public BoxCollider2D boxCollider;

    private Animator anim;
    public float shootSpeed;
    public Transform firePoint;
    private bool isShooting;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        isShooting = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isShooting)
        {
            StartCoroutine(Shoot());
            Debug.Log("DevMode: Press 3 for Enemy Ranged Attack!");
        }

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        if (hit.collider != null && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    IEnumerator Shoot()
    {
        anim.SetTrigger("RangeAttack");
        SoundManager.instance.KuntilanakAttackSFX();

        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return 1;
            }
            else
            {
                return +1;
            }
        }

        isShooting = true;

        GameObject newBullet = Instantiate(nail, firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);

        yield return new WaitForSeconds(1f);
        isShooting = false;
    }
}
