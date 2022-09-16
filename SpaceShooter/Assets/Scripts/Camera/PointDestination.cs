using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDestination : MonoBehaviour
{
    private bool moveToThisPoint;
    private float speedToThisPoint;
    private Vector3 destination;

    public bool MoveToThisPoint { get => moveToThisPoint; set => moveToThisPoint = value; }
    public float SpeedToThisPoint { get => speedToThisPoint; }
    public Vector3 Destination { get => transform.position; }
}
