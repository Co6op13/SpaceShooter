using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public static class TowersPrice
//{
//    static TowersVariable name;
//    static int priceTower;    
//}

[System.Serializable]
struct TowersPrice
{
    public TowersVariable name;
    public int price;
};

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<TowersPrice> price;
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
        if (GameManager.Instance.GetAmountMoney() >= price[0].price)            
        AddTower(TowersVariable.Gutling);
    }
    public void AddFlamethrower()
    {
        if (GameManager.Instance.GetAmountMoney() >= price[1].price)
        {
            GameManager.Instance.GetMoney(price[1].price);
            AddTower(TowersVariable.Flamethrower);
        }
    }

    public void AddPlasmaGun()
    {
        if (GameManager.Instance.GetAmountMoney() >= price[2].price)
            AddTower(TowersVariable.PlasmaGun);
    }
}
