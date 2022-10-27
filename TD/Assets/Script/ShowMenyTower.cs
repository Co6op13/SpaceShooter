using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMenyTower : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField] UI UI;
    //[SerializeField] TowerManager towerManager;    

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ShowTowerMeny");
        UI.Instance.ShowTowerMeny();
        TowerManager.Instance.SetPositionForNewTower(transform.position);
    }


}
