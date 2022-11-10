using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : BaseSelected
{    
    public override void Select()
    {
        UI.Instance.ShowPanelTowerOptios();        
        towerScript.TowerSelected();
        TowerManager.Instance.selectedTower = towerGO;
    }

    public override void Deselect()
    {
        UI.Instance.HideTowerMeny();
        if (towerScript != null)
            towerScript.TowerDeselected();
    }
}
