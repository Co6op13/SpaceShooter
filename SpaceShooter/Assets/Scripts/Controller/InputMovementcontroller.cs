using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovementcontroller : MonoBehaviour
{
    private MovementData movementData;

    private void Awake()
    {
        movementData = GetComponent<MovementData>();
    }

    void Update()
    {
        GetDirection();
    }

    private void GetDirection()
    {
        movementData.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), movementData.Direction.z);
    }
}
