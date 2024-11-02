using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickRegistration : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.isYappingDone)
        {
            GameManager.Instance.isYappingActive = false;
            GameManager.Instance.isYappingDone = false;
            Player.Instance.startPosition = Player.Instance.transform.position;

            if (GameManager.Instance.yapToMinigame == 1)
            {
                Player.Instance.transform.localScale *= 2;
            }
            else if (GameManager.Instance.yapToMinigame == 2)
            {
                Player.Instance.GetComponentInChildren<SpriteRenderer>().color = new Color(0,0,0,0);
            }
            SceneManager.LoadScene(GameManager.Instance.yapToMinigame);
        }
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Minigame1Interact") && !Player.Instance.miniGameOne) // PLACEHOLDER. Will use tags later.
        {
            GameManager.Instance.isYappingActive = true;
            GameManager.Instance.yapToMinigame = 1;
        }
        if (gameObject.CompareTag("Minigame2Interact") && !Player.Instance.miniGameTwo)
        {
            GameManager.Instance.isYappingActive = true;
            GameManager.Instance.yapToMinigame = 2;
        }
    }
}
