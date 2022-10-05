using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDash 
{
    int MaxCountDash { get; set; }
    bool IsDash { get; }
    float DashRange { get; set; }
    float DashTimeReload { get; set; }
    float TimeBetweenDash { get; set; }
    Vector3 Direction { get; }

}
