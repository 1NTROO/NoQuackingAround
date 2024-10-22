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
        if (collision.gameObject.CompareTag("Player"))
        {
            Minigame1Manager.Instance.AddToInventory(gameObject);
        }
    }
}
