using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour, ISelectable
{
    [SerializeField] private SpriteRenderer sprite;

    //[SerializeField] private Transform VisualAreaAttack;
    //[SerializeField] private CircleCollider2D AttackArea;
    //[SerializeField] private Material selectedMaterial;
    //[SerializeField] private Material defaultMaterial;
    private Color defaultColor;
    private ITower tower;

    public void Select()
    {
        tower.TowerSelected();
        //sprite.material.color = Color.green;
        UI.Instance.ShowMenyTowerOptios();
        
        TowerManager.Instance.selectedTower = this.gameObject;
    }
    public void Deselect()
    {
        if (tower != null)
            tower.TowerDeselected();
        //if (sprite != null) sprite.material.color = Color.yellow;
        //StartCoroutine(ClearSelectTower());
        UI.Instance.HideAllMeny();
    }

    private IEnumerator ClearSelectTower()
    {

        yield return new WaitForSeconds(0.2f);
        //TowerManager.Instance.selectedTower = null;
        yield break;
    }

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        //defaultColor = sprite.color;
        tower = GetComponentInParent<ITower>();
    }

    private void EnabeleVisualAttackArea()
    {

    }

}
