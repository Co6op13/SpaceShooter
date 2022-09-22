using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIMController : MonoBehaviour
{
    //[SerializeField] Vector3 directionOnTarget;
    private IAIM dataObject;
    private Transform nearestTarget;

    private void Awake()
    {
        dataObject = GetComponent<IAIM>();
    }

    private void OnEnable()
    {
        StartCoroutine(FindNearestTargets());
    }


    private IEnumerator FindNearestTargets()
    {
        while (gameObject.activeSelf)
        {
            Collider2D[] detected—olLider = Physics2D.OverlapCircleAll(transform.position, dataObject.AgrRadiud
                                                             , dataObject.TargetLayer);
            if (detected—olLider.Length > 0)
            {
                float dist = dataObject.AgrRadiud;
                Collider2D currentCollider = detected—olLider[0];
                foreach (Collider2D collider in detected—olLider)
                {
                    float currentDist = Vector3.Distance(transform.position, collider.transform.position);
                    if (currentDist < dist)
                    {
                        currentCollider = collider;
                        dist = currentDist;
                    }
                }
                nearestTarget = currentCollider.transform;
            }
            yield return new WaitForSeconds(dataObject.TimeSearch);
        }
        yield break;
    }

    private void FixedUpdate()
    {
        if (nearestTarget != null)
        {
            GetAimingAngle();
            ShowDirection();

        }
    }

    private void GetAimingAngle ()
    {
        dataObject = GetComponent<IAIM>();
        dataObject.DirectionOnTarget = (nearestTarget.position - transform.position).normalized;
        dataObject.AimingAngle = GetAngleFromVectorFloat(dataObject.DirectionOnTarget);
    }

    private void ShowDirection()
    {
        Debug.DrawRay(dataObject.PivotWeapon.position, dataObject.DirectionOnTarget*4, Color.yellow);        
    }

    private void OnDrawGizmos()
    {
        if (dataObject != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, dataObject.AgrRadiud);
        }
    }


    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;

        return angle;
    }
}
