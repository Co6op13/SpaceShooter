using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour
{

    [SerializeField] private MovementData moveField;
    [Space]
    [SerializeField] private DashData dashField;
    [Space]

    [Space]
    [SerializeField] [Tooltip("Is it shooting at the moment?")] private bool isShooting = false;
    [Space]
    [SerializeField] [Tooltip("Biding to the camera. For movement in conjunction with the camera. Optional")] private MoveCamera moveCamera;
    [Space]
    [Range(0f, 3f)]
    [SerializeField]
    [Tooltip("The position where the weapon is located.")]
    private Transform pivotWeapon;

    
   
    public bool IsShooting { get => isShooting; set => isShooting = value; }
    

    public Transform PivotWeapon => throw new System.NotImplementedException();


}
