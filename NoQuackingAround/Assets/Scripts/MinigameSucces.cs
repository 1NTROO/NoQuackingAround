using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSucces : MonoBehaviour
{
    [SerializeField] int miniGameResponse;
    [SerializeField] bool turnOn;
    void Start()
    {
        if (turnOn)
        {
            foreach (Transform t in gameObject.transform)
            {
                t.gameObject.SetActive(false);
            }
        }
        else if (!turnOn)
        {
            foreach (Transform t in gameObject.transform)
            {
                t.gameObject.SetActive(true);
            }
        }
    }
    void Update()
    {
        OnAndOff();
    }
    public void OnAndOff()
    {
        switch (miniGameResponse)
        {
            case 1:
                if (Player.Instance.miniGameOne == true && turnOn)
                {
                    foreach (Transform t in gameObject.transform)
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                else if (Player.Instance.miniGameOne == true && !turnOn)
                {
                    foreach (Transform t in gameObject.transform)
                    {
                        t.gameObject.SetActive(false);
                    }
                }
                break;
            case 2:
                if (Player.Instance.miniGameTwo == true && turnOn)
                {
                    foreach (Transform t in gameObject.transform)
                    {
                        t.gameObject.SetActive(true);
                    }
                }
                if (Player.Instance.miniGameTwo == true && !turnOn)
                {
                    foreach (Transform t in gameObject.transform)
                    {
                        t.gameObject.SetActive(false);
                    }
                }
                break;
            default:
                break;
        }
    }
}
