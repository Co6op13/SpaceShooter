using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMove : MonoBehaviour, IAction
{
    private IMovable dataObject;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        dataObject = GetComponent<IMovable>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void DoAction()
    {
        Move();
    }

    private void Move()
    {
        rb2d.velocity = dataObject.Direction * dataObject.CurrentMovementSpeed;
    }
}
