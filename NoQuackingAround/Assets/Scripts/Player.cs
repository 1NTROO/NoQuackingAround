using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; }}

    [SerializeField] int speed;
    [SerializeField] int speedLimit;
    [SerializeField] Rigidbody body;
    [SerializeField] AudioClip patheticPark;
    public Vector3 startPosition;
    public bool miniGameOne, miniGameTwo;

    void Awake()
    {
        if (instance != null) 
        {
            startPosition = instance.gameObject.transform.position;
            miniGameOne = instance.miniGameOne;
            miniGameTwo = instance.miniGameTwo;
            Destroy(instance.gameObject);
        }
        instance = this;

        SetStartPosAndScale(1);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (!miniGameOne && !miniGameTwo)
        {
            AudioManager.Instance.PlayAudio(patheticPark);
        }
        else if (miniGameOne || miniGameTwo)
        {

        }
        else if (miniGameOne && miniGameTwo)
        {
            
        }
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

    // this shit doesn't work lmfao
    // void OnCollisionEnter(Collision collision)
    // {
    //     print(collision.gameObject.name);
    //     if (collision.gameObject.CompareTag("statics"))
    //     {
    //         body.velocity = new Vector3(0, 0, 0);
    //         print("I collided!");
    //     }
    // }

    public void SetStartPosAndScale(float scalar)
    {
        transform.position = startPosition;
        startPosition = Vector3.zero;

        transform.localScale *= scalar;
    }
}
