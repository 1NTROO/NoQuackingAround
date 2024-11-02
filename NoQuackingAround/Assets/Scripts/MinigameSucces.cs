using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSucces : MonoBehaviour
{
    public bool  M1 = false;
    public bool M2 = false;
    public Player script;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnAndOff()
    {
        script = GetComponent<Player>();
        M1 = script.miniGameOne;
        M2 = script.miniGameTwo;

        //if (M1 == true)
        //{

        //}
        //if (M2 == true)
        //{

        //}
    }
}
