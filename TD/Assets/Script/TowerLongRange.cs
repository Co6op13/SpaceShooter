using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLongRange : MonoBehaviour
{
    [SerializeField] private CircleCollider2D areaAttack;
    [SerializeField] private int maxHP;
    private IAttackAction attackAction;
    private IHPConttroller HPcontroller;
    private float distanceAttack;
    private IRotateAction rotateAction;
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private List<GameObject> targets;
    //[SerializeField] private bool isAttack = false;

    private void Awake()
    {
        targets = new List<GameObject>();
        distanceAttack = areaAttack.radius;
        attackAction = GetComponent<IAttackAction>();
        HPcontroller = GetComponent<IHPConttroller>();
        HPcontroller.SetMaxHP(maxHP);
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
            StartCoroutine(RotateToAttack());
        }
        else GetCurrentTarget();

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
}
