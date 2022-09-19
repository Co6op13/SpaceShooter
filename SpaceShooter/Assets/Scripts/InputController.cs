using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IInput))]
public class InputController : MonoBehaviour
{
    private IInput dataObject;

    public IInput DataObject { get => dataObject; set => dataObject = value; }

    private void Awake()
    {
        DataObject = GetComponent<IInput>();
    }


    void Update()
    {
        GetDirection();
        GetDash();
        GetFire();
    }

    private void GetFire()
    {
        if (Input.GetButton("Fire1")) DataObject.IsShooting = true;
    }

    private void GetDirection()
    {
        DataObject.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), DataObject.Direction.z);
    }

    private void GetDash()
    {
        if (Input.GetButtonDown("Dash")) DataObject.IsDash = true;
            
    }


}
