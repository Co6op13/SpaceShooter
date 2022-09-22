using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMStaticTurretData : StaticTurretData, IAIM, ITurn
{
    [SerializeField] private GameObject weapon;
    [Range(0, 20)] [SerializeField] private float turnSpeed;
    [SerializeField] private float aimingAngle;
    [Range(0, 359)] [SerializeField] private float maxANgleRotate;
    [Range(0, 359)] [SerializeField] private float minANgleRotate;
    [SerializeField] [Tooltip("The layer on which the target is located. ")] private LayerMask targetLayer;
    [Range(0, 20)]
    [SerializeField]
    [Tooltip("The distance at which the object will notice the target")] private float argRadius;
    [Range(0f, 2f)]
    [SerializeField]
    [Tooltip("time between searching for the nearest target")] private float timeSearch = 0.5f;
    [SerializeField] private Vector3 directionOnTarget;
    

    public float AimingAngle { get => aimingAngle; set => aimingAngle = value; }
    public LayerMask TargetLayer { get => targetLayer; }
    public float AgrRadiud { get => argRadius;  }
    public float TimeSearch { get => timeSearch; }
    public GameObject Weapon { get => weapon; set => weapon = value; }
    public Vector3 DirectionOnTarget { get => directionOnTarget; set => directionOnTarget = value; }

    public float TurnSpeed => turnSpeed;

    public float MaxAngleRotate => maxANgleRotate;

    public float MinAngleRotate => minANgleRotate;

}
