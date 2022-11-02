using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNEW : MonoBehaviour, IDamagable
{
    //   [SerializeField] private bool triggerd = false;
    [SerializeField] private float speedMovement;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject target;
    //[SerializeField] private float timeToDisableAfterTriger;
    [SerializeField] private int damage;
    [SerializeField] private float curentLifeTime;
    [SerializeField] private TagWhoProjectileAttacked tagWhoProjectileAttacked;
    [SerializeField] private float distanceDamage;
    private float distance;
    private Rigidbody2D rb2d;

    //    private BoxCollider2D collider2D;

    private void OnEnable()
    {
        SetDefaultParamedters();
    }

    private void SetDefaultParamedters()
    {
        curentLifeTime = lifeTime;
        //        triggerd = false;
        //        collider2D.enabled = false;
    }

    private void Start()
    {
        SetDefaultParamedters();
        rb2d = GetComponent<Rigidbody2D>();
        //collider2D = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        rb2d.velocity = transform.right * speedMovement;
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < distanceDamage)
            TakeDamage();
        curentLifeTime -= Time.fixedDeltaTime;
        if (curentLifeTime < 0) gameObject.SetActive(false);
    }


    private void TakeDamage()
    {
        target.GetComponent<IHPConttroller>().TakesDamage(damage);
        gameObject.SetActive(false); gameObject.SetActive(false);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);
    //    if (collision.CompareTag(tagWhoProjectileAttacked.ToString()) && !triggerd)
    //    {
    //        triggerd = true;
    //        collision.gameObject.GetComponent<IHPConttroller>().TakesDamage(damage);
    //        gameObject.SetActive(false); gameObject.SetActive(false);
    //    }
    //}

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
