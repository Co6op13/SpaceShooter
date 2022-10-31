using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWeapon : Weapon
{
    [SerializeField] private ParticleSystem flame;
    [SerializeField] private PolygonCollider2D attackArea;
    [SerializeField] private LayerMask layer;

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
            HPcontroller.TakesDamage(damage);
            StartCoroutine(AddVisualEffect());
            Invoke("CancelAttack", delaySeconds);
        }
    }

    private void GetTargetsOnAttackArea ()
    {
        //Collider2D[] test;
        //Collider2D[] colliders = Physics2D.OverlapCollider(attackArea, layer, test);
    }
}
