using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttackAction
{
    [SerializeField] protected BulletType bulletType;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected GameObject currentTarget;
    [SerializeField] protected int damage;
    [SerializeField] protected Transform firePoint;
    protected float distanceToFirepoint;
    protected float delaySeconds;
    protected bool isAttacked = false;

    private void Start()
    {
        SetDelay();
        distanceToFirepoint = Vector3.Distance(transform.position, firePoint.position);
    }
    private void OnEnable()
    {
        SetDelay();
    }

    private void SetDelay()
    {
        delaySeconds = 1 / attackSpeed;
    }

    private void CancelAttack()
    {
        isAttacked = false;
    }

    protected IHPConttroller GetHPControllerFromTarget(GameObject target)
    {
         return target.GetComponent<IHPConttroller>();
    }

    public void AttackTarget(GameObject target)
    {
        currentTarget = target;
        Attack();
    }

    protected abstract void Attack();



}