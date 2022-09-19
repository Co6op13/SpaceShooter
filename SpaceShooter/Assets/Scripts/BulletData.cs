using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour, IMovable, IDamage
{
    [SerializeField] [Tooltip("The amount of damage caused.")] private int amountDamage;
    [SerializeField] [Tooltip("Maximum movement speed.")] private float maxMovementSpeed;
    private Vector3 direction = Vector3.right;
    private float speedFactor;

    public float CurrentMovementSpeed
    {
        get
        {
            return maxMovementSpeed *  Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
        }

    }
    public Vector3 Direction
    {
        get
        {
            direction.Normalize();
            return direction;
        }
        set => direction = value;
    }
    public float SpeedFactor { get => speedFactor; set => speedFactor = value; }

    public int AmountDamage { get => amountDamage; }
}
