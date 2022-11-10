using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, ITower
{

   // [SerializeField] private bool isSelected;
    [SerializeField] private TowersVariable type;
    [SerializeField] private CircleCollider2D areaAttack;
    [SerializeField] private GameObject VisualAreaAttack;
    [SerializeField] private int maxHP;
    private IAttackAction attackAction;
    private IHPConttroller HPcontroller;
    private float distanceAttack;
    private IRotateAction rotateAction;
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private List<GameObject> targets;

    //public bool IsSelected { get => isSelected; set => isSelected = value; }

    //[SerializeField] private bool isAttack = false;

    public void SetAttackDistance(float distance)
    {
        areaAttack.radius = distance;
    }

    public void SetMaxHP(int maxHP)
    {
        this.maxHP = maxHP;
    }

    public void TowerSelected()
    {
        ShowVisualAttackArea();
    }
    public void TowerDeselected()
    {
        if (VisualAreaAttack != null) VisualAreaAttack.SetActive(false);
    }

    private void Awake()
    {
        targets = new List<GameObject>();
        distanceAttack = areaAttack.radius;
        attackAction = GetComponent<IAttackAction>();
        HPcontroller = GetComponent<IHPConttroller>();
        HPcontroller.SetMaxHP(maxHP);
        rotateAction = GetComponent<IRotateAction>();
    }

    public TowersVariable GetTowerType()
    {
        return type;
    }

    private void OnEnable()
    {
        HPcontroller.SetMaxHP(maxHP);
    }


    private void FixedUpdate()
    {
        if (currentTarget != null && targets.Contains(currentTarget))
        {
            StartCoroutine(RotateToAttack());
        }
        else GetCurrentTarget();
       
    }

    private void ShowVisualAttackArea()
    {
        VisualAreaAttack.SetActive(true);
        float distance = areaAttack.radius;
        VisualAreaAttack.transform.localScale = new Vector3(distance, distance, 1f);
    }

    private IEnumerator RotateToAttack()
    {
        rotateAction.RotateToTarget(currentTarget.transform.position);
        yield return new WaitForSeconds(0.1f);
        attackAction.AttackTarget(currentTarget);
        if (currentTarget.activeSelf == false) DropCuurentTarget(currentTarget);
        yield break;
    }

    private void GetCurrentTarget()
    {
        if (targets.Count > 0)
        {
            currentTarget = targets[targets.Count - 1];
        }
    }

    private void DropCuurentTarget(GameObject target)
    {
        targets.Remove(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DropCuurentTarget(collision.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceAttack);
    }

    private void OnDestroy()
    {
        MyEventManager.SendDestroyTower();
    }


}
