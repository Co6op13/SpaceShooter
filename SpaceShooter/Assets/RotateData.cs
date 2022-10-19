using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AccessoryMetods;

public class RotateData : MonoBehaviour, ITurn
{
    [Range(0, 20)] [SerializeField] private float turnSpeed;
    [Range(0, 359)] [SerializeField] private float maxANgleRotate;
    [Range(0, 359)] [SerializeField] private float minANgleRotate;
    public float TurnSpeed => turnSpeed;
    public float MaxAngleRotate => maxANgleRotate;
    public float MinAngleRotate => minANgleRotate;

    private void OnDrawGizmos()
    {
        if (MinAngleRotate > maxANgleRotate)
        {
            var temp = maxANgleRotate;
            maxANgleRotate = minANgleRotate;
            minANgleRotate = temp;
        }
        Debug.DrawRay(transform.position, GetVectorFromAngle(MaxAngleRotate +
                        transform.rotation.eulerAngles.z) * 3, Color.red);
        Debug.DrawRay(transform.position, GetVectorFromAngle(MinAngleRotate +
                        transform.rotation.eulerAngles.z) * 3, Color.blue);
    }
}
