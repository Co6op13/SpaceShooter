using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamage))]
public class DamageController : MonoBehaviour
{
    private IDamage dataObject;

    private void Awake()
    {
        dataObject = GetComponent<IDamage>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��� ���� ��������. ����� �������� ��������� �����" + collision.name);
        if (collision.GetComponent<MortalController>() != null)
        {
            Debug.Log("MortalController is here");
            collision.GetComponent<MortalController>().TakesDamage(dataObject.AmountDamage);
        }
        gameObject.SetActive(false);
    }  
}
