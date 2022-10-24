using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private PathCreator path;

    public void AddEnemy1()
    {
        AddEnemy(prefab1);
    }

    public void AddEnemy2()
    {
        AddEnemy(prefab2);
    }

    private void AddEnemy(GameObject prefab)
    {
        var enemy = Instantiate(prefab, new Vector3(2f, 2f, 0f), transform.rotation);
        enemy.GetComponent<PathWalker>().SetPath(path.GetComponent<PathCreator>());
    }
}
