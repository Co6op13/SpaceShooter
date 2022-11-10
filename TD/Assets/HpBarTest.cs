using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarTest : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float hp;
    [SerializeField] private float test;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

    }

    private void FixedUpdate()
    {
        material.SetFloat("_CountSegments", test); 
        material.SetFloat("_RemovedSegments", hp);


    }
}
