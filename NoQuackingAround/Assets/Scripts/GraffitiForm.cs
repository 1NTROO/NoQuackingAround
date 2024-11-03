using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraffitiForm : MonoBehaviour
{
    public int points;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Minigame2Manager.Instance.prev = Minigame2Manager.Instance.ReadMouse();
    }
    void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            Minigame2Manager.Instance.isBeingHeld = true;
        }
    }
    void OnMouseExit()
    {
        if (Minigame2Manager.Instance.totalDistance > 250)
        {
            Minigame2Manager.Instance.MouseExit();
            GetComponentInChildren<SpriteRenderer>().color = new Color(255, 0, 0, 0.3f);
        } 
    }
    void OnMouseUp()
    {
        if (Minigame2Manager.Instance.totalDistance != 0)
        {
            Minigame2Manager.Instance.MouseExit();
            GetComponentInChildren<SpriteRenderer>().color = new Color(255, 0, 0, 0.3f);
        } 
    }
}
