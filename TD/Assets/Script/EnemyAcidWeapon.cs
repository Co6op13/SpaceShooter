using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAcidWeapon : Weapon
{
    [SerializeField] private GameObject spittingPrefab;
    protected override void Attack()
    {
        if (!isAttacked)
        {
            isAttacked = true;           
            StartCoroutine(Spitting());
            Invoke("CancelAttack", delaySeconds);
        }
    }

    private IEnumerator Spitting()
    {
        GameObject projectile;
        Debug.Log("test Split");
        yield return new WaitForSeconds(0.1f);
        projectile = ProjectileObjectPool.Instance.GetFromPool(spittingPrefab.name, firePoint.position, firePoint.rotation);
        projectile.layer = LayerMask.NameToLayer("EnemyProjectile");/////////
        var script = projectile.GetComponent<IDamagable>();
        script.SetDamage(damage);
        script.SetTarget(currentTarget);

        yield break;
    }
}
