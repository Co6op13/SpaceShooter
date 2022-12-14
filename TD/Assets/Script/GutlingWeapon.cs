using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutlingWeapon : Weapon
{   
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] private Transform firePoint2;
    protected IHPConttroller HPcontrollerCurrentTarget;

    protected override void Attack()
    {
        if (!isAttacked)
        {
            isAttacked = true;
            StartCoroutine(Shooting());
            Invoke("CancelAttack", delaySeconds);
        }
    }


    protected IEnumerator Shooting()
    {
        GameObject projectile;
        projectile = ProjectileObjectPool.Instance.GetFromPool(bulletPrefab.name, firePoint.position, firePoint.rotation);
        projectile.layer = LayerMask.NameToLayer("TowerProjectile");//////////            
        var script = projectile.GetComponent<IDamagable>();
        script.SetDamage(damage);
        script.SetTarget(currentTarget);
        yield return new WaitForSeconds(0.1f);
        projectile = ProjectileObjectPool.Instance.GetFromPool(bulletPrefab.name, firePoint2.position, firePoint2.rotation);
        projectile.layer = LayerMask.NameToLayer("TowerProjectile");/////////
        script = projectile.GetComponent<IDamagable>();
        script.SetDamage(damage);
        script.SetTarget(currentTarget);
        yield return new WaitForSeconds(0.1f);
        yield break;
    }

    private void CancelAttack()
    {
        isAttacked = false;
    }

}