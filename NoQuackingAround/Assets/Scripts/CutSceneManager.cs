using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    private static CutSceneManager instance;
    public static CutSceneManager Instance { get { return instance;}}

    [SerializeField] float timer = 5f;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }
}
