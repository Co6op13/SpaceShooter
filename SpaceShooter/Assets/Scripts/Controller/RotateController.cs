using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AccessoryMetods;

public class RotateController : MonoBehaviour
{
    [SerializeField] private IArmed weaponData;
    [SerializeField] private IAIM AIMData;
    [SerializeField] private ITurn turnData;
   
    private void Awake()
    {
        turnData = GetComponent<ITurn>();
        AIMData = GetComponent<IAIM>();
        weaponData = GetComponent<IArmed>();
    }

    private void FixedUpdate()
    {
        TurnWeapon();
    }

    void TurnWeapon()
    {
        //Debug.DrawRay(weaponData.PivotDefaultWeapon.position, AIMData.DirectionOnTarget * 8, Color.blue);
        if (AIMData.AimingAngle < turnData.MaxAngleRotate
            && AIMData.AimingAngle > turnData.MinAngleRotate)
        {
            Debug.DrawRay(weaponData.PivotDefaultWeapon.position, AIMData.DirectionOnTarget * 8, Color.blue);
            weaponData.CurrentWeapon.rotation = Quaternion.Slerp(weaponData.CurrentWeapon.rotation,
            Quaternion.Euler(0f, 0f, AIMData.AimingAngle), turnData.TurnSpeed * Time.fixedDeltaTime);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    if (turnData == null)
    //    {
    //        turnData = this.gameObject.GetComponent<ITurn>();
    //    }       
    //        Debug.DrawRay(transform.position, GetVectorFromAngle(turnData.MaxAngleRotate +
    //            weaponData.CurrentWeapon.rotation.eulerAngles.z) * 3, Color.red);
    //        Debug.DrawRay(transform.position, GetVectorFromAngle(turnData.MinAngleRotate +
    //            weaponData.CurrentWeapon.rotation.eulerAngles.z) * 3, Color.blue);

    //}

}
