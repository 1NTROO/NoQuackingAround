using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Manager : MonoBehaviour
{
    private static Minigame1Manager instance;
    public static Minigame1Manager Instance {get {return instance; }}

    public List<GameObject> trashList = new List<GameObject>();

    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (trashList.Count == 0)
        {
            print("Yippee!");
            SceneManager.LoadScene("GameScene");
        }
    }
}
