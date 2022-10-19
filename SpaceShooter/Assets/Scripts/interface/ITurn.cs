using UnityEngine;
internal interface ITurn
{
    float MaxAngleRotate { get; }
    float MinAngleRotate { get; }

    float TurnSpeed { get; }
}