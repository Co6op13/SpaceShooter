using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttackAction
{
    [SerializeField] protected BulletType bullet;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected GameObject currentTarget;
    [SerializeField] protected int damage;
    [SerializeField] protected Transform firePoint;
    protected float distanceToFirepoint;
    protected IHPConttroller HPcontroller;
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

    private void GetHPControllerFromTarget(GameObject target)
    {
        HPcontroller = target.GetComponent<IHPConttroller>();
    }

    public void AttackTarget(GameObject target)
    {
        currentTarget = target;
        GetHPControllerFromTarget(target); //////////////
        Attack();
    }

    protected abstract void Attack();

}