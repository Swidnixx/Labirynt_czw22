using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager SingleInstance;
    [SerializeField] int time = 60;
    bool paused;
    bool ended;

    int diamonds = 0;
    public int goldKeys = 0;
    public int greenKeys = 0;
    public int redKeys = 0;

    //UI
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI diamondsUI;
    public TextMeshProUGUI goldKeysUI;
    public TextMeshProUGUI redKeysUI;
    public TextMeshProUGUI greenKeysUI;
    public Image freezeUI;

    public GameObject pauseScreen;
    public GameObject loseScreen;
    public GameObject winScreen;

    public TextMeshProUGUI infoText;

    private void Awake()
    {
        if(SingleInstance == null)
        {
            SingleInstance = this;
        }
        else
        {
            Debug.LogError("Multiple GMs in the Scene!");
        }
    }
    private void Start()
    {
        InvokeRepeating(nameof(TimerTick), 3, 1);
        DisplayTime();
        DisplayPickups();
        pauseScreen.SetActive(false);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        infoText.text = "";
    }
    private void Update()
    {
        if (ended) return;

        DisplayTime();
        DisplayPickups();
        if (Input.GetButtonDown("Cancel"))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Game Flow Methods
    void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
    void TimerTick()
    {
        time--;
        freezeUI.enabled = false;

        if(time <= 0)
        {
            time = 0;
            GameOver();
        }
    }
    void GameOver()
    {
        ended = true;
        CancelInvoke(nameof(TimerTick));
        time = 0;
        Time.timeScale = 0;
        loseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void Win()
    {
        ended = true;
        Time.timeScale = 0;
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    //Pickup Methods
    public void AddDiamond()
    {
        diamonds++;
    }
    public void AddKey(KeyColor keyColor)
    {
        switch(keyColor)
        {
            case KeyColor.Gold:
                goldKeys++;
                break;

            case KeyColor.Green:
                greenKeys++;
                break;

            case KeyColor.Red:
                redKeys++;
                break;
        }
    }
    public void Freeze(int time)
    {
        freezeUI.enabled = true;
        CancelInvoke();
        InvokeRepeating(nameof(TimerTick), time, 1);
    }
    public void AddTime(int time)
    {
        this.time += time;
    }

    //DisplayMethods
    void DisplayTime()
    {
        TimeSpan ts = new TimeSpan(0, 0, time);
        timeUI.text = ((int)ts.TotalMinutes).ToString() + ":" + ts.Seconds.ToString("d2");
        //timeUI.text = time.ToString();
    }
    void DisplayPickups()
    {
        diamondsUI.text = diamonds.ToString();
        redKeysUI.text = redKeys.ToString();
        greenKeysUI.text = greenKeys.ToString();
        goldKeysUI.text = goldKeys.ToString();
    }
}
