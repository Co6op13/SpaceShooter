using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    private ITurn dataObject;
    private float smooth = 1f;

    private void Awake()
    {
        dataObject = GetComponent<ITurn>();
    }

    private void FixedUpdate()
    {
        TurnWeapon();
    }

    void TurnWeapon ()
    {
        Quaternion rotate = Quaternion.Euler(0, 0, 0);
        rotate.z = dataObject.AimingAngle;
        dataObject.Weapon.transform.rotation = rotate;
        //dataObject.Weapon.transform.rotation = Quaternion.Slerp(dataObject.Weapon.transform.rotation,
        //                                        Quaternion.Euler(dataObject.DirectionOnTarget), 
        //                                        Time.fixedDeltaTime * dataObject.TurnSpeed);
    }
}
