using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartWave : MonoBehaviour, ISelectable
{
    public void Select()
    {
        Debug.Log("StartWawe");
        MyEventManager.SendStartCurrentWave();
        gameObject.SetActive(false);
    }

    public void Deselect() { }
}
