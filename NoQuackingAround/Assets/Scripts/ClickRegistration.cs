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
        if (gameObject.name == "MinigameInteract") // PLACEHOLDER. Will use tags later.
        {
            Player.Instance.startPosition = Player.Instance.transform.position;
            SceneManager.LoadScene("MiniGame1Scene");
            Player.Instance.transform.localScale *= 2;
        }
        if (gameObject.layer == 22) print("Come on.");
    }
}
