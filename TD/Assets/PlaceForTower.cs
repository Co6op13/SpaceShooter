using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForTower : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private Collider2D clickerCollider;
    public void DisableCollider(GameObject tower)
    {
        this.tower = tower;
        clickerCollider.enabled = false;
    }

    private void OnEnable()
    {
        MyEventManager.OnDestroyTower.AddListener(EnableCollider);
        MyEventManager.OnSellTower.AddListener(EnableCollider);
    }

    public void Start()
    {
        clickerCollider = GetComponent<Collider2D>();
    }

    public void EnableCollider()
    {
        if (this.tower != null)
        {
            clickerCollider.enabled = true;
        }
    }
}
