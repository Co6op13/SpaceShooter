using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour, IHPConttroller
{
    [SerializeField] private int currentHP = 1;
    private int maxHP = 1;

    public void SetMaxHP(int hp)
    {
        maxHP = hp;
    }

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    private void Start()
    {
        OnEnable();
    }

    public void TakesDamage(int damage)
    {
        if (currentHP - damage > 0)
        {
            currentHP -= damage;
        }
        else
        {
            currentHP = 0;
            gameObject.SetActive(false);
        }

    }

    public void TakesHeal(int heal)
    {
        if (currentHP + heal <= maxHP)
        {
            currentHP += heal;
        }
        else
        {
            currentHP = maxHP;
        }

    }
}
