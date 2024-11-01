using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public enum TrashType
    {
        White,
        Green,
        Black
    }

    public TrashType thisTrashType;

    [SerializeField] SphereCollider hitBox;
    [SerializeField] SpriteRenderer sprite;
    void Start()
    {
        Array allTypes = Enum.GetValues(typeof(TrashType));
        System.Random random = new();
        thisTrashType = (TrashType)allTypes.GetValue(random.Next(allTypes.Length));

        switch (thisTrashType)
        {
            case TrashType.White:
                sprite.color = Color.white;
                break;
            case TrashType.Green:
                sprite.color = Color.green;
                break;
            case TrashType.Black:
                sprite.color = Color.black;
                break;
            default:
                break;
        }
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
