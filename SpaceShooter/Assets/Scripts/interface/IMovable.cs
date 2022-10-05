using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable 
{
    float CurrentMovementSpeed { get; }
    Vector3 Direction { get; }
    float SpeedFactor { set; }
}
