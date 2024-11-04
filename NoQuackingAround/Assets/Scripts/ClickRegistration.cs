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
            SceneManager.LoadScene(GameManager.Instance.yapToMinigame + 3);
        }
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Minigame1Interact"))
        {
            GameManager.Instance.isYappingActive = true;
            if (!Player.Instance.miniGameOne)
            {
                GameManager.Instance.yapToMinigame = 1;
            }
            else
            {
                GameManager.Instance.yapToMinigame = 3;
            }
        }
        if (gameObject.CompareTag("Minigame2Interact"))
        {
            GameManager.Instance.isYappingActive = true;
            if (!Player.Instance.miniGameTwo)
            {
                GameManager.Instance.yapToMinigame = 2;
            }
            else
            {
                GameManager.Instance.yapToMinigame = 4;
            }
        }
    }
}
