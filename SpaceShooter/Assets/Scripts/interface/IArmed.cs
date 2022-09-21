using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArmed 
{
    bool IsShooting { get; set; }

    Vector3 PivotWeapon { get; }

}
