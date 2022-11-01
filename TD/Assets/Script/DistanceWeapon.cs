using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DistanceWeapon : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    private IHPConttroller HPcontrollerCurrentTarget;
    [SerializeField] private Transform firePoint2;


    protected override void Attack()
    {
        if (!isAttacked)
        {
            isAttacked = true;
            HPcontrollerCurrentTarget = GetHPControllerFromTarget(currentTarget);
            StartCoroutine(AddVisualEffect());
            StartCoroutine(AttackTargt());
            Invoke("CancelAttack", delaySeconds);
        }
    }

    private IEnumerator AttackTargt()
    {
        HPcontrollerCurrentTarget.TakesDamage(damage);
        yield return new WaitForSeconds(delaySeconds);
        yield break;
    }

    protected IEnumerator AddVisualEffect()
    {
        ProjectileObjectPool.Instance.GetFromPool(bulletPrefab.name, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(0.1f);
        ProjectileObjectPool.Instance.GetFromPool(bulletPrefab.name, firePoint2.position, firePoint2.rotation);
        yield return new WaitForSeconds(0.1f);
        ProjectileObjectPool.Instance.GetFromPool(bulletPrefab.name, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(0.1f);
        ProjectileObjectPool.Instance.GetFromPool(bulletPrefab.name, firePoint2.position, firePoint2.rotation);
        yield return new WaitForSeconds(0.1f);
        yield break;
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

    //private  IEnumerator AddVisualEffect()
    //{        
    //    Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
    //    float angle = AccessoryMetods.GetAngleFromVectorFloat(direction);
    //    float distance = Vector3.Distance(currentTarget.transform.position, transform.position) - distanceToFirepoint;
    //    //Debug.Log(distance);
    //    tracers[0].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    //    tracers[0].transform.position = firePoint.position;
    //    tracers[0].transform.localScale =  new Vector3(distance, 1f, 1f);
    //    yield return new WaitForSeconds(0.01f);
    //    tracers[0].SetActive(true);
    //    yield return new WaitForSeconds(0.05f);
    //    tracers[0].SetActive(false);
    //    yield return new WaitForSeconds(0.01f);
    //    yield break;
    //}