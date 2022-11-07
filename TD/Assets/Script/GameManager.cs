using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    //[SerializeField] private bool isPaused;
    [SerializeField] private int startMoney = 300;
    [SerializeField] private int amountMoney;
    [SerializeField] public bool startLavel = false;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        //isPaused = false;
        Time.timeScale = 1;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        MyEventManager.OnTakeMoney.AddListener(AddMoney);
        MyEventManager.OnEnemyKilled.AddListener(AddMoney);
        MyEventManager.OnGetMoney.AddListener(GetMoney);
        MyEventManager.OnPauseDisable.AddListener(GamePauseDisable);
        MyEventManager.OnStartCurrentWave.AddListener(StartSpawnEnemyWaves);
    }

    private void StartSpawnEnemyWaves()
    {
        startLavel = true;
    }

    private void Start()
    {
        AddMoney(startMoney);
    }

    public int GetAmountMoney()
    {
        return amountMoney;
    }

    private void AddMoney(int money)
    {
        if (money > 0)
            amountMoney += money;
        MyEventManager.SendChencheAmountMony();
    }

    private void GetMoney(int money)
    {
        if (amountMoney >= money)
            amountMoney -= money;
        MyEventManager.SendChencheAmountMony();
    }

    public void GamePauseEnable()
    {
        //isPaused = true;
        Time.timeScale = 0;
        MyEventManager.SendPauseEnable();
    }

    public void GamePauseDisable()
    {
        //isPaused = false;
        Time.timeScale = 1;
    }

    //private void OnApplicationPause(bool pause)
    //{
    //    isPaused = true;
    //    Time.timeScale = 0;
    //}

    public void TimeScale()
    {

    }
}
