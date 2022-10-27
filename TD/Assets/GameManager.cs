using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] int AmountMoney = 300;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        MyEventManager.OnEnemyKilled.AddListener(AddMoney);
    }


    public int GetAmountMoney()
    {
        return (AmountMoney);
    }

    private void AddMoney(int money)
    {
        if (money > 0) AmountMoney += money;
    }
}
