using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minigame2Manager : MonoBehaviour
{
    private static Minigame2Manager instance;
    public static Minigame2Manager Instance { get { return instance; }}

    [SerializeField] TMPro.TextMeshProUGUI pointsUI, timerText;

    [SerializeField] List<GameObject> levelsList;
    [SerializeField] GameObject failureUI, successUI;
    [SerializeField] Transform failureParentTransform;
    [SerializeField] AudioClip minigameMusic;
    private GameObject levelNow;
    private int currentLevel = 1;
    public Vector2 prev;
    public float totalDistance;

    public int points;
    public bool isBeingHeld, wasBeingHeld;
    private float timer, baseTimer = 5f/1.1f;
    public int succeeded = 0;
    private int totalFailures = 0;


    public Vector2 ReadMouse()
    {
        Vector3 rawPos = Input.mousePosition;
        return new Vector2( rawPos.x, rawPos.y);
    }

    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }
    void Start()
    {
        isBeingHeld = false;
        // points = 0;
        // pointsUI.text = Convert.ToString("Points: " + points);

        ResetTimer();
        levelNow = Instantiate(levelsList.ElementAt(0), Vector3.zero, Quaternion.identity);

        AudioManager.Instance.PlayAudio(minigameMusic);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        float timerScale = (float)Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(timer))) + 1);
        timerText.text = Convert.ToString(Math.Max(0.01f, timerScale * Math.Round(timer / timerScale, 3)));
        if (timer <= 0)
        {
            if (succeeded < currentLevel + 2)
            {
                totalFailures++;
                UpdateCounter(false);
            }
            else
            {
                UpdateCounter(true);
            }
            ResetTimer();
            // pointMult *= 1.5f;
            if (levelsList.Count() != 1)
            {
                NextLevel(levelsList[1]);
                currentLevel++;
            }
            else
            {
                if (totalFailures > 1)
                {
                    Player.Instance.miniGameTwo = false;
                }
                else Player.Instance.miniGameTwo = true;
                Player.Instance.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 0, 0, 1f);
                SceneManager.LoadScene(0);
                Player.Instance.SetStartPosAndScale(1);
            }
        }

        if (isBeingHeld)
        {
            if (wasBeingHeld == false) wasBeingHeld = true;
            GetMousePos();
        }
    }


    public void GetMousePos()
    {
        Vector2 now = ReadMouse();
        Vector2 delta = now - prev;
        prev = now;
        totalDistance += delta.magnitude;
    }
    public void MouseExit(int addPoints)
    {
        // failureCounter++;
        // UpdateFailureCounter();
        isBeingHeld = false;
        // points += Convert.ToInt32(pointMult * addPoints * totalDistance/100);
        // pointsUI.text = Convert.ToString("Points: " + points);
        totalDistance = 0;
        // if (failureCounter > 3)
        // {
        //     // failImage.enabled = true;
        //     // failImage.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Failed!";
        //     totalFailures++;
        //     if (timer > 1) timer = 1;
        // }
    }
    void NextLevel(GameObject nextLevel)
    {
        levelsList.RemoveAt(0);
        Destroy(GameObject.FindGameObjectWithTag("GraffitiLevel"));
        levelNow = Instantiate(nextLevel, Vector3.zero, Quaternion.identity);

        // change background to next phase
    }
    void ResetTimer()
    {
        // failImage.enabled = false;
        // failImage.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";

        timer = baseTimer;
        timer *= 1.1f;
        baseTimer *= 1.1f;

        // foreach (Transform pip in failureParentTransform.transform)
        // {
        //     Destroy(pip.gameObject);
        // }
    }
    void UpdateCounter(bool isSuccess)
    {
        if (!isSuccess)
            Instantiate(failureUI, failureParentTransform);
        else
            Instantiate(successUI, failureParentTransform);
    }
}
