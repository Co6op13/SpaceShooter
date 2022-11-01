using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : ObjectPooler
{
    #region Singleton
    public static ProjectileObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
}
