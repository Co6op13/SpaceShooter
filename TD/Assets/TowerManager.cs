using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private TowersVariable towersVariable;
    
    public void AddTower(var)
    {
        Instantiate(prefab, new Vector3(2f, 2f, 0f), transform.rotation);
    }








}
