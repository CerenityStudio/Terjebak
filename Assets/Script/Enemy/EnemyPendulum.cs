using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPendulum : MonoBehaviour
{
    #region Public Variables
    public float leftPushRange, rightPushRange;
    public float velocityThreshold;
    #endregion

    #region Private Variable
    private Rigidbody2D rb;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.angularVelocity = velocityThreshold;
    }

    void Update()
    {
        Push();
    }

    public void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightPushRange && (rb.angularVelocity > 0) && rb.angularVelocity < velocityThreshold)
        {
            rb.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > leftPushRange && (rb.angularVelocity < 0) && rb.angularVelocity > velocityThreshold * -1)
        {
            rb.angularVelocity = velocityThreshold * -1;
        }
    }
}
