using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputShootingController : MonoBehaviour
{
    private WeaponData weaponData;


    private void Awake()
    {
        weaponData = GetComponent<WeaponData>();
    }


    void Update()
    {
        SetFire();
    }


    private void SetFire()
    {
        if (Input.GetButton("Fire1"))
        {
            weaponData.IsDefaultShooting = true;
            Invoke("ResetIsDefaultShooting", 0.1f);
        }
        //if (Input.GetButtonDown("Fire2"))
        //{
        //    weaponData.IsAdditionalShooting = true;
        //    Invoke("ResetIsAdditionalShooting", 0.1f);
        //}
    }

    void ResetIsDefaultShooting()
    {
        weaponData.IsDefaultShooting = false;
    }
    //void ResetIsAdditionalShooting()
    //{
    //    weaponData.IsAdditionalShooting = false;
    //}
}
