using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class TriggerEvent : MonoBehaviour
{
    public string targetTag;
    public UnityEvent OnTrigger;
    public UnityEvent<GameObject> OnTriggerWithGameObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Target tag: " + targetTag + ", Collision tag: " + collision.tag);
        if(collision.tag == targetTag)
        {
            OnTrigger?.Invoke();
            OnTriggerWithGameObject?.Invoke(collision.gameObject);
;        }
    }
}
