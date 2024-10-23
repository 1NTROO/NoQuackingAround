using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame2Manager : MonoBehaviour
{
    private static Minigame2Manager instance;
    public static Minigame2Manager Instance { get { return instance; }}

    [SerializeField] TMPro.TextMeshProUGUI pointsUI, timerText;

    [SerializeField] List<GameObject> levelsList;
    private GameObject levelNow;
    public Vector2 prev;
    public float totalDistance;

    public int points;
    private float pointMult = 1;
    public bool isBeingHeld, wasBeingHeld;
    private float timer, baseTimer = 5f/1.1f;


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
            print("You fucked up!");
            ResetTimer();
            pointMult *= 1.5f;
            if (levelsList.Count() != 1)
            {
                NextLevel(levelsList[1]);
            }
            else
            {
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
        isBeingHeld = false;
        points += Convert.ToInt32(pointMult * addPoints * totalDistance/100);
        pointsUI.text = Convert.ToString("Points: " + points);
        totalDistance = 0;
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
        timer = baseTimer;
        timer *= 1.1f;
        baseTimer *= 1.1f;
    }
}
