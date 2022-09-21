using UnityEngine;
internal interface ITurn
{
    Vector3 DirectionOnTarget { get; set; }
    float AimingAngle { get; set; }
    Vector3 PivotWeapon { get; }

    float TurnSpeed { get; }

    GameObject Weapon { get; set; }

}