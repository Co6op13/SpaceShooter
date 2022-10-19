using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DistanceWeapon : MonoBehaviour, IAttackAction
{
    [SerializeField] private BulletType bullet;
    [SerializeField] private float attackSpeed;
    [SerializeField] public GameObject target;
    [SerializeField] private int damage;

    private IHPConttroller HPcontroller;
    private float delaySeconds;
    private bool isAttacked = false;

    private void Start()
    {
        SetDelay();
    }
    private void OnEnable()
    {
        SetDelay();
    }

    private void SetDelay()
    {
        delaySeconds = 1 / attackSpeed;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
        GetHPControllerFromTarget();
    }

    private void GetHPControllerFromTarget()
    {
        HPcontroller = target.GetComponent<IHPConttroller>();
    }

    public IEnumerator Attack()
    {
        isAttacked = true;
        Debug.Log(1);
        while (target.activeSelf)
        {
            Debug.Log(2);
            HPcontroller.TakesDamage(damage);
            yield return new WaitForSeconds(delaySeconds);
        }
        if (!target.activeSelf)
        {
            DropTarget();
            yield break;
        }

    }

    private void DropTarget()
    {
        HPcontroller = null;
        target = null;
        isAttacked = false;
    }

    public void AttackTarget()
    {
       if(!isAttacked) StartCoroutine(Attack());
    }
}
