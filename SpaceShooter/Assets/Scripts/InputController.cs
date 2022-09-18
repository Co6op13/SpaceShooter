using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IInput))]
public class InputController : MonoBehaviour
{
    private IInput dataObject;


    private void Awake()
    {
        dataObject = GetComponent<IInput>();
    }


    void Update()
    {
        GetDirection();
        GetDash();
        GetFire();
    }

    private void GetFire()
    {
        if (Input.GetButton("Fire1")) dataObject.IsShooting = true;
    }

    private void GetDirection()
    {
        dataObject.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), dataObject.Direction.z);
    }

    private void GetDash()
    {
        if (Input.GetButtonDown("Dash")) dataObject.IsDash = true;
            
    }


}
