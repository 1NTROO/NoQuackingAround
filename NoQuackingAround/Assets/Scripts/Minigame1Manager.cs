using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minigame1Manager : MonoBehaviour
{
    private static Minigame1Manager instance;
    public static Minigame1Manager Instance {get {return instance; }}


    [SerializeField] Transform inventoryTransform;
    [SerializeField] GameObject trashUI;
    public List<GameObject> trashList = new List<GameObject>();
    public List<GameObject> trashInventoryList = new List<GameObject>();
    public TMPro.TextMeshProUGUI remainingTrash, timerText;
    private float timer = 25f;
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
            SceneManager.LoadScene("GameScene");
            Player.Instance.SetStartPosAndScale(0.5f);
        }

        if (trashList.Count == 0 && trashInventoryList.Count == 0)
        {
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
        foreach (GameObject t in trashInventoryList)
        {
            if (t.GetComponent<TrashPickup>().thisTrashType == trash.GetComponent<TrashPickup>().thisTrashType) 
                return;
        }
        Instance.trashList.Remove(trash);
        Instance.remainingTrash.text = "Trash remaining: " + Instance.trashList.Count;
        Instance.trashInventoryList.Add(trash);

        trash.GetComponent<SphereCollider>().enabled = false;
        
        GameObject newTrashUI = Instantiate(trashUI, inventoryTransform);

        Color colour = trash.GetComponentInChildren<SpriteRenderer>().color;
        newTrashUI.GetComponentInChildren<Image>().color = colour;
        colour.a = 0;
        trash.GetComponentInChildren<SpriteRenderer>().color = colour;
    }
    public void ClearInventory()
    {
        for (int i = 0; i < trashInventoryList.Count; i++)
        {
            Destroy(trashInventoryList[i]);
        }
        foreach (Transform UI in inventoryTransform)
        {
            Destroy(UI.gameObject);
        }
        trashInventoryList.Clear();
    }
}
