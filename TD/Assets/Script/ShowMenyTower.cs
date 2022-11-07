using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMenyTower : MonoBehaviour, ISelectable
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;
    public void Select()
    {
        sprite.material.color = Color.yellow;
        //sprite.material = selectedMaterial;
        //GetComponent<MeshRenderer>().material.color = Color.red;
        UI.Instance.ShowTowerMeny();
        TowerManager.Instance.SetPositionForNewTower(transform.position);
    }

    public void Deselect()
    {
        sprite.material.color = Color.white;
        //sprite.material = defaultMaterial;
        //GetComponent<MeshRenderer>().material.color = Color.white;
        UI.Instance.HideTowerMeny();        
    }

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        //defaultMaterial = sprite.material;
        
        //GetComponent<MeshRenderer>().material.color = Color.white;
    }
    ////[SerializeField] UI UI;
    ////[SerializeField] TowerManager towerManager;    
    //[SerializeField] private SpriteRenderer sprite;
    //[SerializeField] private Material defaultMaterial;
    //[SerializeField] private Material selectedMaterial;

    //private void Awake()
    //{
    //    sprite = GetComponentInChildren<SpriteRenderer>();
    //    defaultMaterial = sprite.material;
    //}

    ////public void OnPointerClick(PointerEventData eventData)
    ////{
    ////    //Debug.Log("ShowTowerMeny");
    ////    //UI.Instance.ShowTowerMeny();
    ////    //TowerManager.Instance.SetPositionForNewTower(transform.position);
    ////    //sprite.color = Color.yellow;
    ////}

    //public void Selected()
    //{
    //    Debug.Log("ShowTowerMeny");
    //    sprite.material = selectedMaterial;
    //    UI.Instance.ShowTowerMeny();
    //    TowerManager.Instance.SetPositionForNewTower(transform.position);
    //    sprite.color = Color.yellow;
    //}

    //public void Unselcted()
    //{
    //    sprite.material = defaultMaterial;
    //    Debug.Log("HideTowerMeny");
    //    UI.Instance.HideTowerMeny();
    //}
}
