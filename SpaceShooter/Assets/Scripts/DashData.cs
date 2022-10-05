using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(IMovable))]
public class DashData: MonoBehaviour, IDash
{
    [SerializeField] [Tooltip("")] private float dashRange;
    [SerializeField] [Tooltip("")] private float dashTimeReload = 1f;
    [SerializeField] [Tooltip("")] private int maxCountDash = 1;
    [SerializeField] [Tooltip("")] private float timeBetweenDash = 1f;
    [SerializeField] [Tooltip("")] private bool isDash;
    [SerializeField] [Tooltip("Direction of movement")] private Vector3 direction;

    private MovementData movementData;
    public float DashRange { get => dashRange; set => dashRange = value; }
    public float DashTimeReload { get => dashTimeReload; set => dashTimeReload = value; }
    public bool IsDash { get => isDash; set => isDash = value; }
    public int MaxCountDash { get => maxCountDash; set => maxCountDash = value; }
    public float TimeBetweenDash { get => timeBetweenDash; set => timeBetweenDash = value; }
    public Vector3 Direction { get => direction; set => direction = value; }

}