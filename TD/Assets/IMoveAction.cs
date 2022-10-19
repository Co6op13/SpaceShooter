

using UnityEngine;

internal interface IMoveAction
{
    public void Move();
    public void RotateToTarget(Vector3 target);
}