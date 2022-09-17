using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{ 
    [SerializeField] private Vector3 cameraDirection;
    private IMovable dataObject;

    private void Awake()
    {
        dataObject = GetComponent<IMovable>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        cameraDirection = new Vector3(dataObject.Direction.x, dataObject.Direction.y, 0f);
        transform.position = transform.position + (cameraDirection * dataObject.CurrentMovementSpeed * Time.fixedDeltaTime);
    }
}
