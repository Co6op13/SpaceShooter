using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGatling : MonoBehaviour
{

    [SerializeField] private Collider2D distanceAttack;
    [SerializeField] private int maxHP;
    private IAttackAction attackAction;
    private IHPConttroller HPcontroller;

    private IRotateAction rotateAction;
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private bool isAttack = false;

    private void Awake()
    {
        targets = new List<GameObject>();
        attackAction = GetComponent<IAttackAction>();
        HPcontroller = GetComponent<IHPConttroller>();
        rotateAction = GetComponent<IRotateAction>();
    }

    private void OnEnable()
    {
        HPcontroller.SetMaxHP(maxHP);
    }

    private void FixedUpdate()
    {
        
        if (currentTarget != null)
        {
            rotateAction.RotateToTarget(currentTarget.transform.position);
            if (!isAttack) StartCoroutine(Attack());
        }
        else GetCurrentTarget();
    }

    private IEnumerator Attack()
    {
        isAttack = true;
        attackAction.SetTarget(currentTarget);
        Debug.Log("start attack");
        attackAction.AttackTarget();
        yield return new WaitUntil(() => currentTarget.activeSelf == false);
        Debug.Log("end attack");
        DropCuurentTarget();
        isAttack = false;
        yield break;
    }



    private void GetCurrentTarget()
    {
        if (targets.Count > 0)
        {
            currentTarget = targets[targets.Count - 1];
        }
    }

    private void DropCuurentTarget()
    {
        targets.Remove(currentTarget);
        currentTarget = null;
        Debug.Log(targets.Count);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);
        }
    }
}
