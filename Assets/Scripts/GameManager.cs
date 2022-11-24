using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager SingleInstance;
    [SerializeField] int time = 60;
    bool paused;

    int diamonds = 0;
    public int goldKeys = 0;
    public int greenKeys = 0;
    public int redKeys = 0;

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
    }
    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
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

    void Pause()
    {
        paused = true;
        Time.timeScale = 0;
    }
    void Resume()
    {
        paused = false;
        Time.timeScale = 1;
    }
    void TimerTick()
    {
        time--;
        //Debug.Log("Time: " + time);

        if(time <= 0)
        {
            time = 0;
            GameOver();
        }
    }
    void GameOver()
    {
        CancelInvoke(nameof(TimerTick));
    }

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
        CancelInvoke();
        InvokeRepeating(nameof(TimerTick), time, 1);
    }
    public void AddTime(int time)
    {
        this.time += time;
    }
}
