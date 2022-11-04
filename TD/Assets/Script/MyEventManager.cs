using UnityEngine;
using UnityEngine.Events;

public static class MyEventManager
{
    public static UnityEvent<int> OnEnemyKilled = new UnityEvent<int>();
    public static UnityEvent<int> OnGetMoney = new UnityEvent<int>();
    public static UnityEvent OnDestroyBase = new UnityEvent();
    public static UnityEvent OnChencheAmountMony = new UnityEvent();
    public static UnityEvent OnPauseEnable = new UnityEvent();
    public static UnityEvent OnPauseDisable = new UnityEvent();
    public static UnityEvent OnStartCurrentWave = new UnityEvent();
    // public static UnityEvent<int> OnAddTower = new UnityEvent<int>();

    public static void SendEnemyKilled(int monyForKilled)
    {
        OnEnemyKilled.Invoke(monyForKilled);
    }

    public static void SendStartCurrentWave()
    {
        OnStartCurrentWave.Invoke();
    }

    public static void SendPauseEnable()
    {
        OnPauseEnable.Invoke();
    }
    public static void SendPauseDisable()
    {
        OnPauseDisable.Invoke();
    }

    public static void SendOnGetMoney(int money)
    {
        OnGetMoney.Invoke(money);
    }

    public static void SendBaseDestriy()
    {
        OnDestroyBase.Invoke();
    }

    public static void SendChencheAmountMony()
    {
        OnChencheAmountMony.Invoke();
    }
}
