using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWeapon : Weapon
{
    [SerializeField] private ParticleSystem flame;
    [SerializeField] private PolygonCollider2D attackArea;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Collider2D[] collidersEnemyInAttackArea;
    [SerializeField] private float sizeOverlapCircle;
    [SerializeField] private Transform attackAreaCenter;

    protected IEnumerator AddVisualEffect()
    {

        Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
        float angle = AccessoryMetods.GetAngleFromVectorFloat(direction);
        float distance = Vector3.Distance(currentTarget.transform.position, transform.position) - distanceToFirepoint;
        flame.Play();
        yield return new WaitForSeconds(delaySeconds);
        yield break;
    }

    protected override void Attack()
    {
        if (!isAttacked)
        {
            isAttacked = true;
            StartCoroutine(GetTargetsOnAttackArea());
            StartCoroutine(AddVisualEffect());
            StartCoroutine(AttackTargts());
            Invoke("CancelAttack", delaySeconds);
        }
    }

    private IEnumerator AttackTargts()
    {
        foreach (var col in collidersEnemyInAttackArea)
        {
            if (col.gameObject.GetComponent<IHPConttroller>() != null)
            {
                IHPConttroller HP = col.gameObject.GetComponent<IHPConttroller>();
                HP.TakesDamage(damage);
            }
        }
        yield return new WaitForSeconds(delaySeconds);
        yield break;
    }

    private IEnumerator GetTargetsOnAttackArea()
    {
        collidersEnemyInAttackArea = Physics2D.OverlapCircleAll(attackAreaCenter.position, sizeOverlapCircle, layer);
        yield return new WaitForSeconds(delaySeconds);
        yield break;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackAreaCenter.position, sizeOverlapCircle);
    }
}
