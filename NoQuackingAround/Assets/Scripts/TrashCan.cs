using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
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
            if (Minigame1Manager.Instance.trashInventoryList.Count > 0)
            {
                Minigame1Manager.Instance.ClearInventory();
            }
        }
    }
}
