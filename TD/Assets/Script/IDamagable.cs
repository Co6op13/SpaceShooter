using System.Collections;
using UnityEngine;

public interface IDamagable
{
    public void SetDamage(int damage);
    public void SetTarget(GameObject target);
}