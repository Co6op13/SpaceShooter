using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : ObjectPooler
{
    #region Singleton
    public static EnemyObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
}
