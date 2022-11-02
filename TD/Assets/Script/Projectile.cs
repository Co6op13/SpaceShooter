using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TagWhoProjectileAttacked
{
    Enemy,
    Tower
}

public class Projectile : MonoBehaviour, IDamagable
{
    [SerializeField] private bool triggerd = false;
    [SerializeField] private float speedMovement;
    [SerializeField] private float lifeTime;
    [SerializeField] private float timeToDisableAfterTriger;
    [SerializeField] private int damage;
    [SerializeField] private float curentLifeTime;
    [SerializeField] private TagWhoProjectileAttacked tagWhoProjectileAttacked;
    private Rigidbody2D rb2d;

    private void OnEnable()
    {
        SetDefaultParamedters();
    }

    private void SetDefaultParamedters()
    {
        curentLifeTime = lifeTime;
        triggerd = false;
    }

    private void Start()
    {
        SetDefaultParamedters();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb2d.velocity = transform.right * speedMovement;
        curentLifeTime -= Time.fixedDeltaTime;
        if (curentLifeTime < 0) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag(tagWhoProjectileAttacked.ToString()) && !triggerd)
        {
            triggerd = true;
            collision.gameObject.GetComponent<IHPConttroller>().TakesDamage(damage);
            Invoke("DisableProjectile", timeToDisableAfterTriger);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void DisableProjectile()
    {
        gameObject.SetActive(false); gameObject.SetActive(false);
    }

    public void SetTarget(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
