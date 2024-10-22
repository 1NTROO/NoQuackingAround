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
    private Vector3 playerPos;
    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (player != null)
        {
            playerPos = player.transform.position;
            player.GetComponent<Player>().startPosition = playerPos;
        }
    }
}
