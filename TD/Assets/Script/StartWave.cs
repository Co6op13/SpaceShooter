using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartWave : MonoBehaviour, ISelectable
{
    [SerializeField] private Transform sprite;
    private void FixedUpdate()
    {
        sprite.transform.Rotate(new Vector3(0, 2, 0));
        //transform.rotation = Quaternion.Euler(Vector3.right * Time.fixedDeltaTime);
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
        
    //}

    public void Select()
    {
        Debug.Log("StartWawe");
        MyEventManager.SendStartCurrentWave();
        gameObject.SetActive(false);
    }

    public void Deselect()
    {
        throw new System.NotImplementedException();
    }
}
