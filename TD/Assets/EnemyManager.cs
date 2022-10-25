using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private PathCreator path;

    public void AddEnemy1()
    {
        AddEnemy(prefab1.name);
    }

    public void AddEnemy2()
    {
        AddEnemy(prefab2.name);
    }

    private void AddEnemy(String nameEnemy)
    {
        var enemy = EnemyObjectPool.Instance.GetFromPool(nameEnemy, transform.position, transform.rotation);     
        enemy.GetComponent<PathWalker>().SetPath(path.GetComponent<PathCreator>());
    }
}
