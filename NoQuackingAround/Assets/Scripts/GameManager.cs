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
    public bool isYappingActive, isYappingDone;
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
                    npcName.text = "Raquel the Rat";
                    npcText.text = "Please help me! My children are stuck under this pile of human waste. Can you please help them? Oh, dear Nature...";
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
                isYappingDone = true;
            }
        }
    }
}
