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

    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Minigame1Interact")) // PLACEHOLDER. Will use tags later.
        {
            Player.Instance.startPosition = Player.Instance.transform.position;
            SceneManager.LoadScene("MiniGame1Scene");
            Player.Instance.transform.localScale *= 2;
        }
        if (gameObject.CompareTag("Minigame2Interact"))
        {
            Player.Instance.startPosition = Player.Instance.transform.position;
            Player.Instance.GetComponentInChildren<SpriteRenderer>().color = new Color(0,0,0,0);
            SceneManager.LoadScene("MiniGame2Scene");
        }
    }
}
