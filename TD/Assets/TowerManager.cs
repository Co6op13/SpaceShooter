using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private TowersVariable towersVariable;
    
    private void AddTower(TowersVariable towersVariable)
    {
        Debug.Log(towersVariable.ToString());
        Instantiate(Resources.Load("Tower/" + towersVariable.ToString()), new Vector3(2f, 2f, 0f), transform.rotation);
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
