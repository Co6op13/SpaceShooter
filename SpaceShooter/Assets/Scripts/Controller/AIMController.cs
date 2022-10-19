using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIMController : MonoBehaviour
{
    //[SerializeField] Vector3 directionOnTarget;
    private IArmed weaponData;
    private IAIM AIMdata;
    private Transform nearestTarget;

    private void Awake()
    {
        AIMdata = GetComponent<IAIM>();
        weaponData = GetComponentInChildren<IArmed>();
    }

    private void OnEnable()
    {
        StartCoroutine(FindNearestTargets());
    }

    private IEnumerator FindNearestTargets()
    {
        while (gameObject.activeSelf)
        {
            Collider2D[] detected—olLider = Physics2D.OverlapCircleAll(transform.position, AIMdata.AgrRadiud
                                                             , AIMdata.TargetLayer);
            if (detected—olLider.Length > 0)
            {
                float dist = AIMdata.AgrRadiud;
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
            yield return new WaitForSeconds(AIMdata.TimeSearch);
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
        AIMdata.DirectionOnTarget = (nearestTarget.position - transform.position).normalized;
        AIMdata.AimingAngle = GetAngleFromVectorFloat(AIMdata.DirectionOnTarget);
    }

    private void ShowDirection()
    {
        Debug.DrawRay(weaponData.PivotDefaultWeapon.position, AIMdata.DirectionOnTarget*4, Color.yellow);        
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
