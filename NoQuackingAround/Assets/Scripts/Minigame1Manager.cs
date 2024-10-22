using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Manager : MonoBehaviour
{
    private static Minigame1Manager instance;
    public static Minigame1Manager Instance {get {return instance; }}


    [SerializeField] Transform inventoryTransform;
    [SerializeField] GameObject trashUI;
    public List<GameObject> trashList = new List<GameObject>();
    public List<GameObject> trashInventoryList = new List<GameObject>();
    public TMPro.TextMeshProUGUI remainingTrash, timerText;
    private float timer = 20f;

    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }
    void Start()
    {
        remainingTrash.text = "Trash remaining: " + trashList.Count;
    }

    void Update()
    {

        // don't ask me how this works, but it works.
        timer -= Time.deltaTime;
        float timerScale = (float)Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(timer))) + 1);
        timerText.text = Convert.ToString(Math.Max(0.01f, timerScale * Math.Round(timer / timerScale, 3)));

        if (timer <= 0)
        {
            print("Fucking idiot.");
            SceneManager.LoadScene("GameScene");
            Player.Instance.SetStartPosAndScale(0.5f);
        }

        if (trashList.Count == 0 && trashInventoryList.Count == 0)
        {
            print("Yippee!");
            SceneManager.LoadScene("GameScene");
            Player.Instance.SetStartPosAndScale(0.5f);
        }
    }

    public void AddToInventory(GameObject trash)
    {
        if (trashInventoryList.Contains(trash))
        {
            return;
        }
        Instance.trashList.Remove(trash);
        Instance.remainingTrash.text = "Trash remaining: " + Instance.trashList.Count;
        Instance.trashInventoryList.Add(trash);
        Instantiate(trashUI, inventoryTransform);
        Destroy(trash);
    }
    public void RemoveFromInventory(GameObject trash)
    {
        Instance.trashInventoryList.Remove(trash);
        Destroy(inventoryTransform.GetChild(0).gameObject);
    }
}
