using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] private float rateFireInSecond = 2;
    [SerializeField] private GameObject bulletRef;
    [SerializeField] private Transform firePoint;
    [SerializeField] private IArmed dataObject;

    private bool canShooting = true;

    private void Start()
    {
        dataObject = GetComponentInParent<IArmed>();

    }

    private void FixedUpdate()
    {
        Shooting();
        
    }

    public void Shooting()
    {
        try
        {
            if (canShooting && dataObject.IsDefaultShooting)
            {
                var bullet = BulletsObjectPooler.Instance.GetFromPool(bulletRef.name, firePoint.position, firePoint.rotation);
                canShooting = false;                
                Invoke("Reload", 1 / rateFireInSecond);
            }
          
        }
        catch (UnassignedReferenceException ure)
        {
            throw new System.Exception("Field firePoint  is Empty");
        }
        catch (NullReferenceException nre)
        {
            throw new System.Exception("Field bulletRef is Empty");
        }

    }

    void Reload()
    {
        canShooting = true;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Vector2 direction =
    //    Gizmos.DrawRay();
    //}

}
