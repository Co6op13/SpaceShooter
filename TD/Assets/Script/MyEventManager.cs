using UnityEngine;
using UnityEngine.Events;

public class MyEventManager
{
    public static UnityEvent<int> OnEnemyKilled = new UnityEvent<int>();
    public static UnityEvent OnDestroyBase = new UnityEvent();
   // public static UnityEvent<int> OnAddTower = new UnityEvent<int>();

    public static void SendEnemyKilled(int coinsForKilled)
    {
        OnEnemyKilled.Invoke(coinsForKilled);
    }

    //public static void SendAddTower(int coinsForTower)
    //{
    //    OnEnemyKilled.Invoke(coinsForTower);
    //}

    public static void SendBaseDestriy()
    {
        OnDestroyBase.Invoke();
    }
}
