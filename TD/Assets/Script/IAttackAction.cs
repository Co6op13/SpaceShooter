using System.Collections;
using UnityEngine;

public interface IAttackAction
{
    public void SetTarget(GameObject target);

    public IEnumerator Attack();
    public void AttackTarget();
}