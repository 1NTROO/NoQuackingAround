using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    [SerializeField] SphereCollider hitBox;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Collided!");
        if (collision.gameObject.CompareTag("Player"))
        {
            print("yes");
            Minigame1Manager.Instance.AddToInventory(gameObject);
        }
    }
}
