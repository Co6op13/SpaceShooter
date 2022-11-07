using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : BaseSelected
{
    public override void Select()
    {
        tower.TowerSelected();
        UI.Instance.ShowMenyTowerOptios();        
        TowerManager.Instance.selectedTower = this.gameObject;
    }

    public override void Deselect()
    {
        if (tower != null)
            tower.TowerDeselected();
        UI.Instance.HideAllMeny();
    }
}
