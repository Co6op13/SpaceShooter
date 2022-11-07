using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase :Tower
{
    private void OnDestroy()
    {
        MyEventManager.SendBaseDestriy();
    }
}
