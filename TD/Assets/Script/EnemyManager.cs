using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

[System.Serializable]
struct EnemyPrice
{
    public EnemyVariable name;
    public int price;
};

public enum EnemyVariable
{
    test,
    Spitting,
    Tanker,
}

[System.Serializable]
public struct EnemySpawnOptions
{
    public float delay;
    public EnemyVariable type;
}

[System.Serializable]
public class Wawe
{
    [SerializeField] public List<EnemySpawnOptions> enemies;
    [SerializeField] public bool IsActive = false;
    [SerializeField] public bool IsEnd = false;
    private int i = 0;
}

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<EnemyPrice> enemyPrice;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private Vector3 pointSpawn;
    [SerializeField] private Wawe[] waves;
    public static EnemyManager Instance;
    int i = 0;
    int t;

    private void Awake()
    {
        Instance = this;

    }

    private IEnumerator WaitStartLavel()
    {
        yield return new WaitUntil(() => GameManager.Instance.startLavel == true);
        StartCoroutine(ActivationWawe());
        yield break;
    }

    private IEnumerator ActivationWawe()
    {
        foreach (var wawe in waves)
        {
            StartCoroutine(SpawnEnemy(wawe));
            yield return new WaitUntil(() => wawe.IsEnd == true);
        }
        yield break;
    }

    private IEnumerator SpawnEnemy(Wawe wave)
    {
        yield return new WaitForSeconds(2f);
        foreach (var enemy in wave.enemies)
        {
            yield return new WaitForSeconds(enemy.delay);
            Debug.Log(enemy.type + "   i =" + i + "  " + enemy.delay);
            AddEnemy(enemy.type);
            i++;
        }
        wave.IsEnd = true;
        yield break;
    }

    private void Start()
    {
        StartCoroutine(WaitStartLavel());
    }

    public void AddEnemy1()
    {
        AddEnemy(EnemyVariable.Spitting);
    }

    public void AddEnemy2()
    {
        AddEnemy(EnemyVariable.Tanker);
    }

    public void AddEnemy(EnemyVariable nameEnemy)
    {
        Debug.Log(nameEnemy.ToString());
        var enemy = EnemyObjectPool.Instance.GetFromPool(nameEnemy.ToString(), pointSpawn, transform.rotation);
        enemy.transform.position = pointSpawn;
        enemy.GetComponent<PathWalker>().SetPath(pathCreator.GetComponent<PathCreator>());
    }

    public void AddMoneyForkillEnemy(EnemyVariable variable)
    {
        int i = enemyPrice.FindIndex(enemyPrice => enemyPrice.name == variable);
        MyEventManager.SendEnemyKilled(enemyPrice[i].price);
    }


}
