using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTower : HP, IHPConttrollerTower
{
    public IEnumerator Repair(float timeTick, int hpRecoveryInOneTick)
    {
        while( currentHP < maxHP)
        {
            TakesHeal(hpRecoveryInOneTick);
            yield return new WaitForSeconds(timeTick);
        }
        yield break;
    }

    public void RepairTower(float timeTick, int hpRecoveryInOneTick)
    {
        StartCoroutine( Repair(timeTick, hpRecoveryInOneTick));
    }
}
