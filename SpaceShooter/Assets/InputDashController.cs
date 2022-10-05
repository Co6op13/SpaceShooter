using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDashController : MonoBehaviour
{
    private DashData dashData;

    private void Awake()
    {
        dashData = GetComponent<DashData>();
    }


    void Update()
    {
        SetDirection();
        SetDash();
    }


    private void SetDash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            dashData.IsDash = true;
            Invoke("ResetIsDash", 0.5f);
        }
    }

    void ResetIsDash()
    {
        dashData.IsDash = false;
    }
    private void SetDirection()
    {
        dashData.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), dashData.Direction.z);
    }

}
