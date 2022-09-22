using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMortal))]
public class MortalController : MonoBehaviour
{
    private IMortal dataobject;

    private void Awake()
    {
        dataobject = GetComponent<IMortal>();
        dataobject.CurrentHP = dataobject.MaxHP;

    }


    public void TakesDamage (int damage)
    {
        if (dataobject.CurrentHP - damage > 0)
        {
            dataobject.CurrentHP -= damage;
        } 
        else
        {
            dataobject.CurrentHP = 0;
            gameObject.SetActive(false);
        }

    }

    public void TakesHeal(int heal)
    {
        if (dataobject.CurrentHP + heal <= dataobject.MaxHP)
        {
            dataobject.CurrentHP += heal;
        }
        else
        {
            dataobject.CurrentHP = dataobject.MaxHP;           
        }

    }
}
