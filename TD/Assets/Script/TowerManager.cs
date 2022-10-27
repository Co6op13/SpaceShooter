using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] string directoryToTowerPrefabs;
    [SerializeField] private int coins;
    [SerializeField] private TowersVariable towersVariable;
    [SerializeField] private Vector3 positionForNewTower = Vector3.zero;

    public static TowerManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void AddTower(TowersVariable towersVariable)
    {
        Debug.Log(towersVariable.ToString());
        if (positionForNewTower !=  Vector3.zero)
        {
            Instantiate(Resources.Load(directoryToTowerPrefabs + towersVariable.ToString()), positionForNewTower, transform.rotation);
            positionForNewTower = Vector3.zero;
        }
    }

    public void SetPositionForNewTower(Vector3 position)
    {
        positionForNewTower = position;
    }

    public void AddGutling()
    {
        AddTower(TowersVariable.Gutling);
    }
    public void AddFlamethrower()
    {
        AddTower(TowersVariable.Flamethrower);
    }
}
