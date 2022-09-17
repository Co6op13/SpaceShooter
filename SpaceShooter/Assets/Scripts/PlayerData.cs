using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour, IMovable, IMortal, IInput
{
    [SerializeField] private float maxMovementSpeed;
    [SerializeField] private float speedFactor; //baf debaff coefficient
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    [SerializeField] private Vector3 direction;
    [SerializeField] private bool isShooting = false;

    private float boostMovementSpeed;
    private float currentMovementSpeed;
    public float MaxMovementSpeed { get => maxMovementSpeed; set => maxMovementSpeed = value; }
    public float CurrentMovementSpeed 
    {
        get
        {
            boostMovementSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
            return currentMovementSpeed = maxMovementSpeed * speedFactor;
        }
        
        set => currentMovementSpeed = value; 
    }
    public int MaxHP { get => maxHP; set => maxHP = maxHP > 0 ? value : maxHP; }
    public int CurrentHP { get => currentHP; set => currentHP = value >=0 ? value: currentHP; }
    public Vector3 Direction 
    { 
        get 
        { 
            direction.Normalize();
            return direction;
        } 
        set => direction = value; 
    }
    public bool IsShooting { get => isShooting; set => isShooting = value; }
    public float SpeedFactor { get => speedFactor; set => speedFactor = value; }

    private void Awake()
    {
        currentHP = maxHP;
    }

}
