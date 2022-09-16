using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable 
{
    float CurrentMovementSpeed { get; set; }
    Vector3 Direction { get; set; }
}
