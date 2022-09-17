using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamage))]
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
    }

    private void GetDirection()
    {
        dataObject.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), dataObject.Direction.z);
    }


}
