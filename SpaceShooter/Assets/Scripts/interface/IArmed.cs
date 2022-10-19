using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArmed 
{    
    bool IsDefaultShooting { get; set; }
   // bool IsAdditionalShooting { get; set; }

    public Transform PivotDefaultWeapon { get; }
    public Transform CurrentWeapon { get; set; }
    //   public Transform PivotAdditionaltWeapon { get; }

    void SetDefaultWeapon(GameObject weapon);

  //  void SetAdditionalWeapon(GameObject weapon);
}
