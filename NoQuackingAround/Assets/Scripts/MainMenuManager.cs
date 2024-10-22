using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager instance;
    public static MainMenuManager Instance { get { return instance; }}

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
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RollCredits()
    {
        // nothing yet
    }
}
