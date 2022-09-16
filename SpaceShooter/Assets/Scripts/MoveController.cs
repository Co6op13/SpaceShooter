using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    private PlayerData data;
    private Rigidbody2D rb;
    private void Awake()
    {
        data = GetComponent<PlayerData>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = data.Direction * data.CurrentMovementSpeed;
    }
}
