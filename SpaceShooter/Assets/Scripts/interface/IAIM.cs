using UnityEngine;

internal interface IAIM
{
    Transform PivotWeapon { get; }
    Vector3 DirectionOnTarget { get; set; }
    float AimingAngle { get; set; }
    LayerMask TargetLayer { get;}
    float AgrRadiud { get; }

    float TimeSearch { get; }
}
  