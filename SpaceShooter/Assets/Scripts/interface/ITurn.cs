using UnityEngine;
internal interface ITurn
{
    Vector3 DirectionOnTarget { get; set; }
    float AimingAngle { get; set; }
    Transform PivotWeapon { get; }

    float MaxAngleRotate { get; }
    float MinAngleRotate { get; }

    float TurnSpeed { get; }

    GameObject Weapon { get; set; }

}