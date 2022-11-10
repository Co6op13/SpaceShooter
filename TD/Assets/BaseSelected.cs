using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSelected : MonoBehaviour, ISelectable
{
    [SerializeField] protected GameObject towerGO;
    protected ITower towerScript;
    
    public virtual void Select()
    {
        towerScript.TowerSelected();
    }

    public virtual void Deselect()
    {
        if (towerScript != null)
            towerScript.TowerDeselected();
    }

    protected void Start()
    {
      
        towerScript = GetComponentInParent<ITower>();
    }

}
