using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalData : MonoBehaviour, IMortal
{
    [SerializeField] [Tooltip("Maximum HP. No buffs or debuff.")] private int maxHP;
    [SerializeField] [Tooltip("")] private int currentHP;
    [SerializeField] [Tooltip("")] private bool Immortal;

    public int MaxHP { get => maxHP; set => maxHP = maxHP > 0 ? value : maxHP; }
    public int CurrentHP
    {
        get => currentHP;
        set
        {
            currentHP = Immortal? currentHP : currentHP = value;
        }
    }
}
