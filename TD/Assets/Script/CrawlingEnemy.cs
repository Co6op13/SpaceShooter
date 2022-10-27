using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingEnemy : MonoBehaviour
{
    [SerializeField] private Collider2D distanceAttack;
    [SerializeField] private int priceToKill;
    [SerializeField] private int maxHP;
    private IAttackAction attackAction;
    private IMoveAction moveAction;
    private IRotateAction rotateAction;
    private IHPConttroller HPcontroller;
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private bool isAttack = false;

    private void Awake()
    {
        targets = new List<GameObject>();
        moveAction = GetComponent<IMoveAction>();
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

        if (currentTarget != null && targets.Contains(currentTarget))
        {
            rotateAction.RotateToTarget(currentTarget.transform.position);
            attackAction.AttackTarget(currentTarget);
            if (currentTarget.activeSelf == false) DropCuurentTarget(currentTarget);
        }
        else
        {
            moveAction.Move();
            GetCurrentTarget();
        }
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
        Debug.Log(targets.Count);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            DropCuurentTarget(collision.gameObject);
        }
    }

    private void OnDisable()
    {
        MyEventManager.SendEnemyKilled(priceToKill);        
    }
}