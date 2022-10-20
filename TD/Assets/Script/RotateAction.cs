using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AccessoryMetods;

public class RotateAction : MonoBehaviour, IRotateAction
{
    [SerializeField] private float speedRotateAttack = 0.5f;
    public void RotateToTarget(Vector3 target)
    {
        var direction = target - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation,
                   Quaternion.Euler(0f, 0f, GetAngleFromVectorFloat(direction.normalized) + 90), speedRotateAttack);
    }
}
