using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DistanceWeapon : MonoBehaviour, IAttackAction
{
    [SerializeField] private BulletType bullet;
    [SerializeField] private float attackSpeed;
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private int damage;
    [SerializeField] private Material tracerMatertial;
    [SerializeField] private GameObject[] tracers;
   // [SerializeField] private float scrollSpeed;
    [SerializeField] private Transform firePoint;
    private float distanceToFirepoint;
    private IHPConttroller HPcontroller;
    private float delaySeconds;
    private bool isAttacked = false;

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

    private void GetHPControllerFromTarget(GameObject target)
    {
        HPcontroller = target.GetComponent<IHPConttroller>();
    }


    public void AttackTarget(GameObject target)
    {
        currentTarget = target;
        GetHPControllerFromTarget(target);
        if (!isAttacked)
        {
            isAttacked = true;
            HPcontroller.TakesDamage(damage);
            //StartCoroutine(AddVisualEffect());
            Invoke("CancelAttack", delaySeconds);
                
        }
    }


     private  IEnumerator AddVisualEffect()
    {        
        Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
        float angle = AccessoryMetods.GetAngleFromVectorFloat(direction);
        float distance = Vector3.Distance(currentTarget.transform.position, transform.position) - distanceToFirepoint;
        //Debug.Log(distance);
        tracers[0].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        tracers[0].transform.position = firePoint.position;
        tracers[0].transform.localScale =  new Vector3(distance, 1f, 1f);
        yield return new WaitForSeconds(0.01f);
        tracers[0].SetActive(true);
        yield return new WaitForSeconds(0.05f);
        tracers[0].SetActive(false);
        yield return new WaitForSeconds(0.01f);
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
