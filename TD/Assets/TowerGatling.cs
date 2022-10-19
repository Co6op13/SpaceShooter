using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGatling : MonoBehaviour
{

    [SerializeField] private Collider2D distanceAttack;
    [SerializeField] private int maxHP;
    private IAttackAction attackAction;
    private IMoveAction moveAction;
    private IHPConttroller HPcontroller;
    private GameObject targetToAttack;

    private void Awake()
    {
        moveAction = GetComponent<IMoveAction>();
        attackAction = GetComponent<IAttackAction>();
        HPcontroller = GetComponent<IHPConttroller>();
    }

    private void OnEnable()
    {
        HPcontroller.SetMaxHP(maxHP);
    }


}
