using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; }}

    [SerializeField] AudioSource source;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayAudio(AudioClip clip)
    {
        AudioSource newSource = Instantiate(source);
        newSource.clip = clip;
        newSource.volume = 1f;

        newSource.Play();

        Destroy(newSource, clip.length);
    }

    public void StopAudio()
    {
        
    }
}
