using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; }}

    [SerializeField] GameObject player;
    public Canvas canvas;
    [SerializeField] TMPro.TextMeshProUGUI npcName, npcText;
    private List<string> texts = new List<string>();
    public bool isYappingActive, isYappingDone;
    public int howManyYaps = 0, yapsMax;
    public int yapToMinigame;

    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }
    void Start()
    {
        if (canvas.enabled) canvas.enabled = false;
        isYappingActive = false;
        isYappingDone = false;
    }

    void Update()
    {
        if (isYappingActive)
        {
            switch (yapToMinigame)
            {
                case 1:
                    yapsMax = 1;
                    npcName.text = "Raquel the Rat";
                    texts.Add("Please help me! My children are stuck under this pile of human waste. Can you please help them? Oh, dear Nature...");
                    texts.Add("I tried doing it myself, but the waste is too heavy! Maybe if you pick up different types of waste, you can carry more of it?");
                    npcText.text = texts[howManyYaps];
                    break;
                case 2:
                    npcName.text = "Vandalised Board";
                    npcText.text = "You see a vandalised board. It suggests feeding bread to the ducks of the park. As a duck, you know this is a terrible choice, and have to do something about it.";
                    break;
                default:
                    break;
            }
            canvas.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (howManyYaps < yapsMax)
                {
                    howManyYaps++;
                    npcText.text = texts[howManyYaps];
                }
                else
                    isYappingDone = true;
            }
        }
    }
}
