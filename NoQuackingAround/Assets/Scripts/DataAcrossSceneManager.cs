using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAcrossSceneManager : MonoBehaviour
{
    private static DataAcrossSceneManager instance;
    public static DataAcrossSceneManager Instance { get { return instance; }}


    #nullable enable
    [SerializeField] GameObject? player;
    #nullable disable
    void Awake()
    {
        if (instance != null) Destroy(instance.gameObject);
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {

    }
}
