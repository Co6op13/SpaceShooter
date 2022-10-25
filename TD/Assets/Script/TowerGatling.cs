using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGatling : MonoBehaviour
{

    [SerializeField] private CircleCollider2D areaAttack;
    [SerializeField] private int maxHP;
    private IAttackAction attackAction;
    private IHPConttroller HPcontroller;
    [SerializeField] private float distanceAttack;
    private IRotateAction rotateAction;
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private bool isAttack = false;

    private void Awake()
    {
        distanceAttack = areaAttack.radius;
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
        if (currentTarget != null && targets.Contains(currentTarget))
        {
            rotateAction.RotateToTarget(currentTarget.transform.position);
            attackAction.AttackTarget(currentTarget);
            if (currentTarget.activeSelf == false) DropCuurentTarget(currentTarget);
        }
        else GetCurrentTarget();

    }

    //private IEnumerator Attack()
    //{
    //    attackAction.AttackTarget(currentTarget);

    //    // yield return new WaitUntil(() => currentTarget.activeSelf == false);       
    //    //DropCuurentTarget();
    //    isAttack = false;
    //    yield break;
    //}



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
}
