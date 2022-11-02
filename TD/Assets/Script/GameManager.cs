using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] int amountMoney = 300;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        MyEventManager.OnEnemyKilled.AddListener(AddMoney);
        //MyEventManager.OnAddTower.AddListener(AddTower);
    }


    public int GetAmountMoney()
    {
        return (amountMoney);
    }

    private void AddMoney(int money)
    {
        if (money > 0) amountMoney += money;
    }

    public void GetMoney(int money)
    {
        if (amountMoney >= money)
            amountMoney -= money;
    }
    //private void AddTower(int money)
    //{

    //}
}
