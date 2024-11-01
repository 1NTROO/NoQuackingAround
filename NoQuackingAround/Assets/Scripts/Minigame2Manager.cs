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
    [SerializeField] Image failImage;
    private GameObject levelNow;
    public Vector2 prev;
    public float totalDistance;

    public int points;
    private float pointMult = 1;
    public bool isBeingHeld, wasBeingHeld, failed;
    private float timer, baseTimer = 5f/1.1f;
    private int failureCounter = 0;
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
        points = 0;
        pointsUI.text = Convert.ToString("Points: " + points);

        ResetTimer();
        levelNow = Instantiate(levelsList.ElementAt(0), Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        float timerScale = (float)Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(timer))) + 1);
        timerText.text = Convert.ToString(Math.Max(0.01f, timerScale * Math.Round(timer / timerScale, 3)));
        if (timer <= 0)
        {
            failureCounter = 0;
            ResetTimer();
            pointMult *= 1.5f;
            if (levelsList.Count() != 1)
            {
                NextLevel(levelsList[1]);
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
        failureCounter++;
        isBeingHeld = false;
        points += Convert.ToInt32(pointMult * addPoints * totalDistance/100);
        pointsUI.text = Convert.ToString("Points: " + points);
        totalDistance = 0;
        if (failureCounter > 6)
        {
            failImage.enabled = true;
            failImage.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Failed!";
            totalFailures++;
            if (timer > 1) timer = 1;
        }
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
        failImage.enabled = false;
        failImage.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";

        timer = baseTimer;
        timer *= 1.1f;
        baseTimer *= 1.1f;
    }
}