using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase :TowerLongRange
{
    private void OnDestroy()
    {
        MyEventManager.SendBaseDestriy();
    }
}
