using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingEnemy : MonoBehaviour
{
    [SerializeField] private Collider2D distanceAttack;
    [SerializeField] private int maxHP;
    private IAttackAction attackAction;
    private IMoveAction moveAction;
    private IHPConttroller HPcontroller;
    [SerializeField] private GameObject targetToAttack;
    private bool isAttack = false;

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

    private void FixedUpdate()
    {
        if (!isAttack) moveAction.Move();
        if (isAttack) {
            moveAction.RotateToTarget(targetToAttack.transform.position);
            attackAction.SetTarget(targetToAttack);
            attackAction.AttackTarget();
            if (!targetToAttack.activeSelf) isAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            targetToAttack = collision.gameObject;
            isAttack = true;
        }
    }





}
