using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour, IMovable, IDamage
{
    [SerializeField] [Tooltip("The amount of damage caused.")] private int amountDamage;
    [SerializeField] [Tooltip("Maximum movement speed.")] private float maxMovementSpeed;
    private float speedFactor;

    public float CurrentMovementSpeed
    {
        get
        {
            return maxMovementSpeed *  Mathf.Clamp(Direction.magnitude, 0.0f, 1.0f);
        }

    }
    public Vector3 Direction { get => transform.right; set => throw new System.NotImplementedException(); }

    public float SpeedFactor { get => speedFactor; set => speedFactor = value; }

    public int AmountDamage { get => amountDamage; }
  
}
