using System;
using System.Collections;
using UnityEngine;

public class SelectedManager : MonoBehaviour
{
   // [SerializeField] private float raycastMaxDistance = 50f;
    [SerializeField] private LayerMask layerForFindCollider;
    [SerializeField] private LayerMask layerForSelect;
    [SerializeField] private GameObject selectGFX;
    public bool selecting = false;
    private Ray ray;
    private RaycastHit2D[] hits;
    [SerializeField] public ISelectable toBeSelected;
    [SerializeField] public ISelectable detectedObject;

    public void BeginSelection()
    {
        if (selecting)
            return;
        selecting = true;
        Deselect();
    }


    private void Deselect()
    {
        if (toBeSelected != null)
        {
            toBeSelected.Deselect();
            DisableVisualSelected();
        }
    }

    public void ConfirmSelection()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics2D.RaycastAll(ray.origin, ray.direction, 10f, layerForFindCollider);
        //Debug.DrawRay(ray.origin, ray.direction * raycastMaxDistance, Color.magenta, 3f);
        for (int i = 0; i < hits.Length; ++i)
        {
            ISelectable selectable = hits[i].collider.GetComponentInParent<ISelectable>();

            if (selectable == null)
                continue;
            //Debug.Log(selectable);
            StartCoroutine(ProcessRaycastHit(selectable));
            return;
        }
        //Deselect();
        //Cleanup();
    }

    private IEnumerator ProcessRaycastHit(ISelectable selectable)
    {
        detectedObject = null;
        yield return new WaitForFixedUpdate();
        //Debug.Log(selectable + " 22222");
        TryAddToDetected(selectable);
        FinalizeSelection();
        yield break;
    }

    private void TryAddToDetected(ISelectable selectable)
    {
        //Debug.Log(selectable + " 3333");
        if (selectable == null)
            return;
        if (detectedObject == selectable)
            return;
        detectedObject = selectable;
    }

    private void FinalizeSelection()
    {
        Deselect();
        toBeSelected = detectedObject;        
        if (layerForSelect >> toBeSelected.gameObject.layer == 1)            
            EnableVisualSelected();
        toBeSelected.Select();
        Cleanup();
    }

    private void EnableVisualSelected()
    {
        selectGFX.transform.position = toBeSelected.gameObject.transform.position;
        selectGFX.SetActive(true);
    }
    private void DisableVisualSelected()
    {
        selectGFX.SetActive(false);
    }

    private void Cleanup()
    {
        selecting = false;
        detectedObject = null;
    }
}
