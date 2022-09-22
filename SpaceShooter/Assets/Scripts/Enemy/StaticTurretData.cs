using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTurretData : MonoBehaviour, IMortal, IArmed
{
    [SerializeField] [Tooltip("Maximum HP. No buffs or debuff.")] private int maxHP;
    [SerializeField] [Tooltip("")] private int currentHP;
    [Space]
    [SerializeField] [Tooltip("Is it shooting at the moment?")] private bool isShooting = false;
    [Space]
    [SerializeField] [Tooltip("The position where the weapon is located.")] private Transform pivotWeapon;

    public int MaxHP { get => maxHP; set => maxHP = maxHP > 0 ? value : maxHP; }
    public int CurrentHP { get => currentHP; set => currentHP = value; }
    public bool IsShooting { get => true; set => isShooting = value; }
    public Transform PivotWeapon { get => pivotWeapon; }
}

