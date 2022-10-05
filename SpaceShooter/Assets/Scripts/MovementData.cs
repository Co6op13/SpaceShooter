using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementData : MonoBehaviour, IMovable
{
    [SerializeField] [Tooltip("Maximum movement speed. No buffs or debuff.")] private float maxMovementSpeed = 10;
    [SerializeField] [Tooltip("Coefficient for buff or debuff. from 0f to 2f.")] private float speedFactor = 1;
    [SerializeField] [Tooltip("Direction of movement")] private Vector3 direction;

    public float MaxMovementSpeed { get => maxMovementSpeed; set => maxMovementSpeed = value; }
    public float CurrentMovementSpeed
    {
        get { return maxMovementSpeed * speedFactor * Mathf.Clamp(direction.magnitude, 0.0f, 1.0f); }

    }
    public float SpeedFactor { get => speedFactor; set => speedFactor = value; }
    public Vector3 Direction
    {
        get
        {
            direction.Normalize();
            return direction;
        }
        set => direction = value;
    }
}