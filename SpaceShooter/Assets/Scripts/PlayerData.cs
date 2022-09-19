using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour, IMovable, IMortal, IInput, IDash, IArmed
{

    [SerializeField] [Tooltip("Maximum movement speed. No buffs or debuff.")] private float maxMovementSpeed;
    [SerializeField] [Tooltip("Coefficient for buff or debuff. from 0f to 2f.")] private float speedFactor; //baf debaff coefficient
    [SerializeField] [Tooltip("Direction of movement")] private Vector3 direction;
    [Space]
    [SerializeField] [Tooltip("")] private float dashAmount;
    [SerializeField] [Tooltip("")] private float dashTimeReload = 1f;
    [SerializeField] [Tooltip("")] private int maxCountDash = 1;
    [SerializeField] [Tooltip("")] private float timeBetweenDash = 1f;
    [SerializeField] [Tooltip("")] private bool isDash;
    [Space]
    [SerializeField] [Tooltip("Maximum HP. No buffs or debuff.")] private int maxHP;
    [SerializeField] [Tooltip("")] private int currentHP;
    [Space]
    [SerializeField] [Tooltip("Is it shooting at the moment?")] private bool isShooting = false;
    [Space]
    [SerializeField] [Tooltip("Biding to the camera. For movement in conjunction with the camera. Optional")] private MoveCamera moveCamera;
    public float MaxMovementSpeed { get => maxMovementSpeed; set => maxMovementSpeed = value; }
    public float CurrentMovementSpeed
    {
        get { return maxMovementSpeed * speedFactor * Mathf.Clamp(direction.magnitude, 0.0f, 1.0f); }

    }
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
    public int MaxHP { get => maxHP; set => maxHP = maxHP > 0 ? value : maxHP; }
    public int CurrentHP { get => currentHP; set => currentHP = value >= 0 ? value : currentHP; }
    public float DashAmount { get => dashAmount; set => dashAmount = value; }
    public float DashTimeReload { get => dashTimeReload; set => dashTimeReload = value; }
    public bool IsDash { get => isDash; set => isDash = value; }        
    public float SpeedFactor { get => speedFactor; set => speedFactor = value; }
    public bool IsShooting { get => isShooting; set => isShooting = value; }
    public int MaxCountDash { get => maxCountDash; set => maxCountDash = value; }
    public float TimeBetweenDash { get => timeBetweenDash; set => timeBetweenDash = value; }

    private void Awake()
    {
        currentHP = maxHP;
    }

}
