using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; }}

    [SerializeField] float speed;
    [SerializeField] int speedLimit;
    [SerializeField] Rigidbody body;
    [SerializeField] AudioClip patheticPark, halfSavedPark, fixedPark;
    public Vector3 startPosition;
    public bool miniGameOne, miniGameTwo;
    public Animator animator;

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
        animator = GetComponent<Animator>();
        if (!miniGameOne && !miniGameTwo)
        {
            AudioManager.Instance.PlayAudio(patheticPark);
        }
        else if (miniGameOne || miniGameTwo)
        {
            AudioManager.Instance.PlayAudio(halfSavedPark);
        }
        else if (miniGameOne && miniGameTwo)
        {
            AudioManager.Instance.PlayAudio(fixedPark);
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
        animator.SetFloat("Velocity", moveVector.x);
        animator.SetFloat("Velocity", moveVector.y);
        moveVector *= Time.deltaTime;

        body.AddRelativeForce(moveVector);
        if (body.velocity.magnitude > speedLimit)
        {
            body.velocity = Vector3.ClampMagnitude(body.velocity, speedLimit);
        }

        if (miniGameOne && miniGameTwo)
        {
            GameManager.Instance.canvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(3);
            }
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
