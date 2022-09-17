using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour, IMovable, IMortal, IInput
{
    [SerializeField] [Tooltip("Biding to the camera. For movement in conjunction with the camera. Optional")] private MoveCamera moveCamera;
    [SerializeField] [Tooltip("Maximum movement speed. No buffs or debuff.")] private float maxMovementSpeed;
    [SerializeField] [Tooltip("Coefficient for buff or debuff. from 0f to 2f.")]  private float speedFactor; //baf debaff coefficient
    [SerializeField] [Tooltip("Maximum HP. No buffs or debuff.")] private int maxHP;
    [SerializeField] [Tooltip("")] private int currentHP;
    [SerializeField] [Tooltip("Direction of movement")] private Vector3 direction;
    [SerializeField] [Tooltip("Is it shooting at the moment?")] private bool isShooting = false;

    private float boostMovementSpeed;
    private float currentMovementSpeed;
    public float MaxMovementSpeed { get => maxMovementSpeed; set => maxMovementSpeed = value; }
    public float CurrentMovementSpeed 
    {
        get
        {
            boostMovementSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
            return  maxMovementSpeed * speedFactor;
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
            if (moveCamera != null) direction = direction + moveCamera.CameraDirection;
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
