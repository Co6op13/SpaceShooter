using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using static AccessoryMetods;

public class PathWalker : MonoBehaviour, IMoveAction
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    private float distanceTravelled;
    private float speedRotateAttack = 0.5f;

    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

  
    public void RotateToTarget(Vector3 target)
    {
        var direction = target - transform.position;
        //var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
       // transform.rotation = pathCreator.path.
        //transform.rotation = Quaternion.Euler(0f, 0f, GetAngleFromVectorFloat(direction.normalized) + 90);
        transform.rotation =  Quaternion.Slerp( transform.rotation,
                   Quaternion.Euler(0f, 0f, GetAngleFromVectorFloat(direction.normalized) + 90), speedRotateAttack);
    }

    public void Move()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance2d(distanceTravelled, endOfPathInstruction);
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

}
