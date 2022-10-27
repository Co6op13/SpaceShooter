using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DistanceWeapon : MonoBehaviour, IAttackAction
{
    [SerializeField] private BulletType bullet;
    [SerializeField] private float attackSpeed;
    //[SerializeField] private GameObject target;
    [SerializeField] private int damage;
    //[SerializeField] private float distanceAttack = 1f;
    [SerializeField] private LineRenderer visualAttack;

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


    private void GetHPControllerFromTarget(GameObject target)
    {
        HPcontroller = target.GetComponent<IHPConttroller>();
    }


    public void AttackTarget(GameObject target)
    {
        GetHPControllerFromTarget(target);
        if (!isAttacked)
        {
            isAttacked = true;
            HPcontroller.TakesDamage(damage);
            Invoke("CancelAttack", delaySeconds);
        }
    }


    private void CancelAttack()
    {
        isAttacked = false;
    }

}

    //public void SetTarget(GameObject target)
    //{
    //    this.target = target;
    //    GetHPControllerFromTarget();
    //}

    //public IEnumerator Attack()
    //{
    //    float distance = Vector3.Distance(target.transform.position, transform.position);
    //    isAttacked = true;
    //    while (target.activeSelf && distance < distanceAttack)
    //    {           
    //        HPcontroller.TakesDamage(damage);
    //        yield return new WaitForSeconds(delaySeconds);
    //    }
    //    if (!target.activeSelf || distance > distanceAttack)
    //    {
    //        DropTarget();
    //        yield break;
    //    }

    //}
    //public void AttackTarget()
    //{
    //   if(!isAttacked) StartCoroutine(Attack());
    //}

    //private IEnumerator Attack()
    //{
        
    //    yield return new WaitForSeconds(delaySeconds);
    //    isAttacked = false;
    //    yield break;
    //}
