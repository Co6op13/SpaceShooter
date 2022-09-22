using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AccessoryMetods;

public class RotateController : MonoBehaviour
{
    [SerializeField] private ITurn dataObject;
   
    private void Awake()
    {
        dataObject = GetComponent<ITurn>();
    }

    private void FixedUpdate()
    {
        TurnWeapon();
    }

    void TurnWeapon()
    {
        if (dataObject.AimingAngle < dataObject.MaxAngleRotate
            && dataObject.AimingAngle > dataObject.MinAngleRotate)
        {
            dataObject.Weapon.transform.rotation = Quaternion.Slerp(dataObject.Weapon.transform.rotation,
            Quaternion.Euler(0f, 0f, dataObject.AimingAngle), dataObject.TurnSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        if (dataObject == null)
        {
            dataObject = this.gameObject.GetComponent<ITurn>();
        }       
            Debug.DrawRay(dataObject.PivotWeapon.position, GetVectorFromAngle(dataObject.MaxAngleRotate +
                transform.eulerAngles.z) * 3, Color.red);
            Debug.DrawRay(dataObject.PivotWeapon.position, GetVectorFromAngle(dataObject.MinAngleRotate +
                transform.eulerAngles.z) * 3, Color.blue);

    }

}
