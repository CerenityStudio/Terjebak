using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float distanceAhead;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);

        //Camera Inertia
        lookAhead = Mathf.Lerp(lookAhead, (distanceAhead * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
