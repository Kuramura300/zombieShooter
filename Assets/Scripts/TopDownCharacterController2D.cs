using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rigidbodyComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rigidbodyComponent.velocity = new Vector2(x, y) * speed;
        rigidbodyComponent.angularVelocity = 0.0f;
    }
}
