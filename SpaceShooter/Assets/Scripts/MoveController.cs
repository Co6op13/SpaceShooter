using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(IMovable))]
public class MoveController : MonoBehaviour
{
    private IMovable dataObject;
    private Rigidbody2D rb;
    private void Awake()
    {
        dataObject = GetComponent<IMovable>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = dataObject.Direction * dataObject.CurrentMovementSpeed;
    }
}
