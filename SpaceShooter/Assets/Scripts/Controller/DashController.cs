using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(IDash))]
public class DashController : MonoBehaviour
{
    private IDash dataObject;
    private Rigidbody2D rb;
    private bool prepareForNextDash = true;
    private int currenCountDash;


    private void Awake()
    {
        dataObject = GetComponent<IDash>();
        rb = GetComponent<Rigidbody2D>();
        currenCountDash = dataObject.MaxCountDash;
    }

    private void FixedUpdate()
    {
        if (currenCountDash > 0 && prepareForNextDash && dataObject.IsDash)
        {
            if (dataObject.Direction != Vector3.zero) Dash(dataObject.Direction);
            else Dash(Vector3.left);
            currenCountDash -= 1;
            prepareForNextDash = false;
            Invoke("PrepareForNextDash", dataObject.TimeBetweenDash);
        }
       // else dataObject.IsDash = false;
        if (currenCountDash <= dataObject.MaxCountDash) Invoke("DashReload", dataObject.DashTimeReload);
    }

    private void Dash( Vector3 direction)
    {
        Vector3 dashPosition = transform.position + direction * dataObject.DashRange;
        rb.MovePosition(dashPosition);
      //  dataObject.IsDash = false;        
    }

    private void DashReload()
    {
        currenCountDash += 1;
    }

    private void PrepareForNextDash ()
    {
        prepareForNextDash = true;
    }
}
