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
    PlasmaGun,
    Base
}

//public static class RepairTower
//{
//    [SerializeField] public static float SpeedRecovery;


//    private static IEnumerator StartRecovery(float SpeedRecovery, IHPConttroller hp)
//    {
//        if (hp.MaxHP > hp.CurrentHP)
//        {
//            hp.CurrentHP += 10;
//            yield return new WaitForSeconds(SpeedRecovery);
//        }
//    }

//}

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<TowersPrice> towerPrice;
    [Space(20)]
    [SerializeField] string directoryToTowerPrefabs;
    [Space(20)]
    [Range(0, 1)] [SerializeField] public float timeTick = 0.1f;
    [SerializeField] public int hpRecoveryInOneTick = 1;
    [Space(20)]
    [SerializeField] public GameObject selectedTower;
    public static TowerManager Instance;
    private GameObject positionForNewTower;
    //private TowersVariable towersVariable;

    private void OnEnable()
    {
        MyEventManager.OnSellTower.AddListener(SellTower);
        //MyEventManager.OnCreateTower.AddListener(AddTower);
    }

    private void Awake()
    {
        Instance = this;
    }
    private void AddTower(TowersVariable variable)
    {
        Debug.Log(variable.ToString());
        if (positionForNewTower != null)
        {
            int i = towerPrice.FindIndex(towerPrice => towerPrice.name == (variable));
            Debug.Log(i);
            if (GameManager.Instance.GetAmountMoney() >= towerPrice[i].price)
            {
                MyEventManager.SendOnGetMoney(towerPrice[i].price);
                GameObject newTower =  Instantiate(Resources.Load(directoryToTowerPrefabs + variable.ToString()),
                    positionForNewTower.transform.position, transform.rotation) as GameObject;
                DisableColliderOnPlaceForTower(newTower);
                positionForNewTower = null;
            }
        }
    }

    public void DisableColliderOnPlaceForTower(GameObject newTower)
    {
        positionForNewTower.GetComponent<PlaceForTower>().DisableCollider(newTower);
    }

    public void SetPositionForNewTower(GameObject positionForTower)
    {
        positionForNewTower = positionForTower;
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

    public void SellTower()
    {
        Debug.Log(1);
        var type = selectedTower.GetComponent<Tower>().GetTowerType();
        Debug.Log(2);
        var HP = selectedTower.GetComponent<IHPConttroller>();
        float percentHP = (1f / HP.MaxHP) * HP.CurrentHP;
        Debug.Log("maxHP = " + HP.MaxHP + "   currentHP = " + HP.CurrentHP + "   percent = " + percentHP);
        int index = towerPrice.FindIndex(towerPrice => towerPrice.name == (type));
        ////////////////////////////////////////////////////////////////////
        MyEventManager.SendOnTakeMoney((int)(towerPrice[index].price * percentHP * 0.8f));
        //////////////////////////
        Debug.Log(3);
        Destroy(selectedTower);
    }


    public void RepairSelectedTower()
    {
        Debug.Log(selectedTower);
        selectedTower.GetComponentInParent<IHPConttrollerTower>().RepairTower(timeTick, hpRecoveryInOneTick);
    }
}
