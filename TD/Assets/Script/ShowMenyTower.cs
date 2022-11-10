using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMenyTower : MonoBehaviour, ISelectable
{
    public void Select()
    {
        UI.Instance.ShowPanelCreateTower();
        TowerManager.Instance.SetPositionForNewTower(gameObject);
    }

    public void Deselect()
    {
        UI.Instance.HideTowerMeny();
    }
}
