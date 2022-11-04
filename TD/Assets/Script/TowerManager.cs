using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct TowersPrice
{
    public TowersVariable name;
    public int price;
};

public enum TowersVariable
{
    Gutling,
    Flamethrower,
    PlasmaGun
}

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<TowersPrice> towerPrice;
    [SerializeField] string directoryToTowerPrefabs;
    [SerializeField] private TowersVariable towersVariable;
    [SerializeField] private Vector3 positionForNewTower = Vector3.zero;
    public static TowerManager Instance;

    private void Awake()
    {
        Instance = this;      
    }
    private void AddTower(TowersVariable variable)
    {
        Debug.Log(variable.ToString());
        if (positionForNewTower != Vector3.zero)
        {
            int i = towerPrice.FindIndex(towerPrice => towerPrice.name == (variable));
            Debug.Log(i);
            if (GameManager.Instance.GetAmountMoney() >= towerPrice[i].price)
            {
                MyEventManager.SendOnGetMoney(towerPrice[i].price);
                Instantiate(Resources.Load(directoryToTowerPrefabs + variable.ToString()), positionForNewTower, transform.rotation);
                positionForNewTower = Vector3.zero;
            }
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

    public void AddPlasmaGun()
    {
        AddTower(TowersVariable.PlasmaGun);
    }
}
