using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGFX : MonoBehaviour
{
    [SerializeField] private Transform sprite;
    [SerializeField] private Vector3 rotateDirectionAndSpeed;
    private void FixedUpdate()
    {
        sprite.transform.Rotate(rotateDirectionAndSpeed);
        //transform.rotation = Quaternion.Euler(Vector3.right * Time.fixedDeltaTime);
    }
}
