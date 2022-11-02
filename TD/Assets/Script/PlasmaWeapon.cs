using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaWeapon : Weapon
{
    [SerializeField] protected GameObject bulletPrefab;
    protected IHPConttroller HPcontrollerCurrentTarget;
    protected IEnumerator Shooting()
    {
        GameObject projectile;
        projectile = ProjectileObjectPool.Instance.GetFromPool(bulletPrefab.name, firePoint.position, firePoint.rotation);
        projectile.layer = LayerMask.NameToLayer("TowerProjectile");//////////            
        var script = projectile.GetComponent<IDamagable>();
        script.SetDamage(damage);
        yield return new WaitForSeconds(0.1f);
        yield break;
    }


    protected override void Attack()
    {
        if (!isAttacked)
        {
            isAttacked = true;
            StartCoroutine(Shooting());
            Invoke("CancelAttack", delaySeconds);
        }
    }
    
    private void CancelAttack()
    {
        isAttacked = false;
    }
}
