using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActionInput : MonoBehaviour, TestIAction
{
    private IInput dataObject;

    private void Awake()
    {
        dataObject = GetComponent<IInput>();
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

    public void DoAction()
    {
        GetFire();
        GetDirection();
        GetDash();
    }
}
