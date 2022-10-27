using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class PathWalker : MonoBehaviour, IMoveAction
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    private float distanceTravelled;
    private float randomOffsetX, randomOffsetY;

    private void OnEnable()
    {
        distanceTravelled = 0;
    }
    void Start()
    {
        randomOffsetY = Random.Range(-3f, 3f);
        randomOffsetX = Random.Range(-3f, 3f);

        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    public void SetPath (PathCreator path)
    {
        pathCreator = path;
    }

    public void Move()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction)
                                    + new Vector3 (randomOffsetX,randomOffsetY,0f);
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
