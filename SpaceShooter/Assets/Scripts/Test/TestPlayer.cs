using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour, IInput, IMovable
{ 
    [SerializeField] [Tooltip("Maximum movement speed. No buffs or debuff.")] private float maxMovementSpeed;
    [SerializeField] [Tooltip("Coefficient for buff or debuff. from 0f to 2f.")] private float speedFactor; //baf debaff coefficient
    [SerializeField] [Tooltip("Direction of movement")] private Vector3 direction;
    [Space]
    [SerializeField] [Tooltip("Biding to the camera. For movement in conjunction with the camera. Optional")] private MoveCamera moveCamera;
    [Space]
    [SerializeField] [Tooltip("")] private bool isDash;
    [Space]
    [SerializeField] [Tooltip("Is it shooting at the moment?")] private bool isShooting = false;

    private TestIAction actionMove;
    private TestIAction actionInput;

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
    public bool IsDash { get => isDash; set => isDash = value; }
    public float SpeedFactor { get => speedFactor; set => speedFactor = value; }
    public bool IsShooting { get => isShooting; set => isShooting = value; }


    private void Awake()
    {
        actionMove = GetComponent<TestActionMove>();
        actionInput = GetComponent<TestActionInput>();
    }

    private void Update()
    {
        actionInput.DoAction();
    }

    private void FixedUpdate()
    {
        actionMove.DoAction();        
 
    }

}
