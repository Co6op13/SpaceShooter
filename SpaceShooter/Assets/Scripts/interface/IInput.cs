using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    Vector3 Direction { get; set; }
    bool IsDash { get; set; }
    bool IsShooting { get; set; }
}
    