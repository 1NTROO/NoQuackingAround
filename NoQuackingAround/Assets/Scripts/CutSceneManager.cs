using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    private static CutSceneManager instance;
    public static CutSceneManager Instance { get { return instance;}}

    [SerializeField] float timer = 5f;
    [SerializeField] int targetScene;
    [SerializeField] Image image;

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
        image.enabled = true;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            image.enabled = false;
            SceneManager.LoadScene(0);
        }
    }
}
