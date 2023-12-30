using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    [Header("Main Settings")] [SerializeField]
    private GameObject player;

    [SerializeField] private float speed;
    [SerializeField] private int _health;

    [Header("Attack Settings")]
    private bool _isCooldown;
    [SerializeField] private float attackCooldown;

    public Animator animator;
    public bool IsBloom = false;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    //Enemy taking damage
    public virtual void TakeDamage(int damageValue)
    {
        Health -= damageValue;
    }

    //Enemy die
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Attack()
    {
        StartCoroutine(AttackCooldown());
    }
    
    private void Awake()
    {
        if (Random.Range(0, 10) < 4)
        {
            IsBloom = true;
            speed = speed * 2;
            _health = _health * 2;
            attackCooldown = attackCooldown / 2;
        }
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        tag = "Enemy";
        StartCoroutine(AttackCooldown());
    }
    
    //Enemy move logic

    private void FixedUpdate()
    {
        if (_isCooldown == false)
        {
            Attack();
        }
    }

    private void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position,
            player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private IEnumerator AttackCooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        _isCooldown = false;
    }
}
