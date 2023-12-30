using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleShooterEnemy : Enemy
{
    [SerializeField] private Weapon weapon;
    
    const string ShootgunEnemy_Born = "ShootgunEnemy_Born";
    const string ShootgunEnemy= "ShootgunEnemy";
    const string ShootgunEnemyBloom= "ShootgunEnemyBloom";
    
    public override void Attack()
    {
        base.Attack();
        weapon.MultipleFire();
    }

    private void Start()
    {
        animator.Play(ShootgunEnemy_Born);
    }

    private void LateUpdate()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ShootgunEnemy_Born"))
        {
            if (IsBloom)
            {
                animator.Play("ShootgunEnemyBloom");
            }
            else
            {
                animator.Play("ShootgunEnemy");
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
