using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputShootingController : MonoBehaviour
{
    [SerializeField] private FireKey fireKey = FireKey.Fire1;
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
        if (Input.GetButton(fireKey.ToString()))
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
