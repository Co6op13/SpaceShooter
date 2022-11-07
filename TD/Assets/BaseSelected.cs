using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSelected : MonoBehaviour, ISelectable
{
    protected ITower tower;
    
    public virtual void Select()
    {
        tower.TowerSelected();
    }

    public virtual void Deselect()
    {
        if (tower != null)
            tower.TowerDeselected();
    }

    protected void Start()
    {
        tower = GetComponentInParent<ITower>();
    }

}
