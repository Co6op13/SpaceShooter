using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using Waypoints;

public class LineSplineWalker : MonoBehaviour, IMovable
{
    [SerializeField] private bool useSpeedOnWaypoint;
    [SerializeField] [Tooltip("First Waypoint PATH.")] private Waypoint currentWaypoint;
    [SerializeField] [Tooltip("Current MAX speed Movement.")] private float maxMovementSpeed;
    [SerializeField] [Tooltip("Coefficient for baf, debaf speed Movement.")] private float speedFactor = 1f; 
    [SerializeField] [Tooltip("The distance between the GameObject and the waypoint before it goes to the next one.")] private float _distanceThreshold;

    [SerializeField] [Tooltip("When the agent has passed a waypoint and looking for the next.")] private UnityEvent OnPassedWaypoint;
    [SerializeField] [Tooltip("After the agent has followd the path to the end.")] private UnityEvent OnFinishedPath;
    [SerializeField]  private Vector3 direction;
    private float boostMovementSpeed;
    private float currentMovementSpeed;
    public float CurrentMovementSpeed
    {
        get
        {            
            boostMovementSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
            if (useSpeedOnWaypoint && currentWaypoint != null) currentMovementSpeed = currentWaypoint.SpeedMovemetntToPoint * speedFactor;
            else currentMovementSpeed = maxMovementSpeed * speedFactor;
            return currentMovementSpeed;
        }

        set => currentMovementSpeed = value;
    }
    public Vector3 Direction
    {
        get
        {
            direction.Normalize();
            return direction;
        }
        set => direction = value;
    }
    public float SpeedFactor { get => speedFactor; set => speedFactor = value; }


    void Start()
    {
        StartCoroutine(Follow_Path());
    }

    protected void Waypoint_Translate()
    {
        Vector2 currentWaypointV2 = new Vector2(currentWaypoint.transform.position.x, currentWaypoint.transform.position.y);
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        direction = currentWaypointV2 - currentPosition;
        direction.Normalize();
        Debug.DrawLine(transform.position, direction + transform.position, Color.yellow);
    }

    private IEnumerator Follow_Path()
    {
        while (currentWaypoint)
        {

            if (Vector2.Distance(transform.position, currentWaypoint.transform.position) <= _distanceThreshold)//get the next waypoint
            {
                currentWaypoint = currentWaypoint.GetNextWaypoint();
                OnPassedWaypoint.Invoke();
            }
            else
                Waypoint_Translate();

            yield return new WaitForFixedUpdate();
        }
        direction = Vector3.zero;
        OnFinishedPath.Invoke();
    }
}
