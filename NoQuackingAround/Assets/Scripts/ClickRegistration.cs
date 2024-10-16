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
        print("Yep.");
        if (gameObject.name == "MinigameInteract")
        {
            SceneManager.LoadScene("MiniGame1Scene");
        }
        if (gameObject.layer == 23)
        {
            Minigame1Manager.Instance.trashList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
