using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarTower : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private IHPConttroller HPController;
    [Range(0, 1)] [SerializeField] private float multiplerForOffsetSegments;
    [SerializeField] private const string RemovedSegments = "_RemovedSegments";
    [SerializeField] private const string CountSegments = "_CountSegments";
    private float currentSegmentCount;
    private float currentRemovedSegments;

    // Start is called before the first frame update
    private void Start()
    {
        HPController = GetComponentInParent<IHPConttroller>();
        material = GetComponent<SpriteRenderer>().material;
        currentSegmentCount = Mathf.Round(HPController.MaxHP * multiplerForOffsetSegments);
        material.SetFloat(CountSegments, currentSegmentCount);
        StartCoroutine(SetHPinBar());
    }


    private IEnumerator SetHPinBar()
    {
        while (gameObject != null)
        {
            currentRemovedSegments = (HPController.MaxHP - HPController.CurrentHP) * multiplerForOffsetSegments;
            material.SetFloat(RemovedSegments, currentRemovedSegments);
            yield return new WaitForSeconds(0.2f);
        }
        yield break;
    }
}
