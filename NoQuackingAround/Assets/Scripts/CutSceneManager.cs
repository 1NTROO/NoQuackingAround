using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    private static CutSceneManager instance;
    public static CutSceneManager Instance { get { return instance;}}


    [SerializeField] float timer = 5f;
    [SerializeField] int targetScene;
    [SerializeField] AudioClip clip;

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
        if (targetScene == 0 || targetScene == 3)
        {
            AudioManager.Instance.PlayAudio(clip);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(targetScene);
        }
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(targetScene);
            }
        }
    }
}
