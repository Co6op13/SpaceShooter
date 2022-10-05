
using UnityEngine;

public interface IInput
{
    Vector3 Direction { get; set; }
    bool IsDash { get; set; }
    bool IsShooting { get; set; }

}
    