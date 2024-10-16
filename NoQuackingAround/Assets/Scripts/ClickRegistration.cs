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
        if (gameObject.name == "MinigameInteract") // PLACEHOLDER. Will use tags later.
        {
            SceneManager.LoadScene("MiniGame1Scene");
        }
        if (gameObject.layer == 23)
        {
            Minigame1Manager.Instance.trashList.Remove(gameObject);
            Minigame1Manager.Instance.remainingTrash.text = "Trash remaining: " + Minigame1Manager.Instance.trashList.Count;
            Destroy(gameObject);
        }
    }
}
