using System.Collections;
using System.Collections.Generic;
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
        print("uh huh");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Minigame1Manager.Instance.trashInventoryList.Count > 0)
            {
                Minigame1Manager.Instance.RemoveFromInventory(Minigame1Manager.Instance.trashInventoryList[0]);
            }
        }
    }
}
