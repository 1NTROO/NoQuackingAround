using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int speedLimit;
    [SerializeField] Rigidbody2D body;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 moveVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x += -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x += speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveVector.y += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector.y += -speed;
        }

        body.AddRelativeForce(moveVector);
        if (body.velocity.magnitude > speedLimit)
        {
            body.velocity = Vector3.ClampMagnitude(body.velocity, speedLimit);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("statics"))
        {
            body.velocity = new Vector3(0, 0, 0);
            print("I collided!");
        }
    }
}
