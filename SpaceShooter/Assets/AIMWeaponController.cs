using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIMWeaponController : MonoBehaviour
{
    [SerializeField] [Tooltip("")] private LayerMask targetLayer;
    [SerializeField] [Tooltip("")] private float speedRotate;
    [Range(0, 359)] [SerializeField] [Tooltip("")] private float maxRotate;
    [Range(0, 359)] [SerializeField] [Tooltip("")] private float minRotate;
    [Range(0, 20)] [SerializeField] [Tooltip("")] private float argRadius;
    [SerializeField] private float targetDirectionAngle = 90;


    private GameObject[] targets;
    private int directionAngle;

    GameObject Target { get; set; }
    GameObject Weapon { get; set; }

    private void Start()
    {
        //StartCoroutine(FindTargets());
    }

    private void FindTargets ()
    {
        var cols =Physics2D.OverlapCircleAll(transform.position, argRadius, targetLayer);

        float dist = argRadius;
        Collider2D currentCollider;

        foreach (Collider2D col in cols)
        {
            float currentDist = Vector3.Distance(transform.position, col.transform.position);
            if (currentDist < dist)
            {
                currentCollider = col;
                dist = currentDist;
            }
        }     

    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, GetVectorFromAngle
            (targetDirectionAngle) * 5, Color.white);
        Debug.DrawRay(transform.position, GetVectorFromAngle(maxRotate +
            transform.eulerAngles.z) * 3, Color.red);
        Debug.DrawRay(transform.position, GetVectorFromAngle(minRotate +
            transform.eulerAngles.z) * 3, Color.blue);
    }

    void MoveWeapon()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(0f, 0f, directionAngle - 90), speedRotate);

    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
