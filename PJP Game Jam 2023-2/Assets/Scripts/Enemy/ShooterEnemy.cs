using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private String animationBorn;
    [SerializeField] private String animation;
    [SerializeField] private String animationBloom;


    public override void Attack()
    {
        base.Attack();
        weapon.Fire();
    }

    private void Start()
    {
        animator.Play(animationBorn);
    }
    
    private void LateUpdate()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationBorn))
        {
            if (IsBloom)
            {
                animator.Play(animationBloom);
            }
            else
            {
                animator.Play(animation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }
}
