using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMData : MonoBehaviour, IAIM
{
    [SerializeField] private float aimingAngle;
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
    public float AgrRadiud { get => argRadius; }
    public float TimeSearch { get => timeSearch; }
    public Vector3 DirectionOnTarget { get => directionOnTarget; set => directionOnTarget = value; }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, AgrRadiud);
    }


    //public static Vector3 GetVectorFromAngle(float angle)
    //{
    //    // angle = 0 -> 360
    //    float angleRad = angle * (Mathf.PI / 180f);
    //    return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    //}
}
