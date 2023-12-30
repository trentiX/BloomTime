using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShieldEnemy : Enemy
{
    public int numBullets = 12;
    public float rotationSpeed = 2f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private void Start()
    {
        CreateBulletShield();
    }

    private void CreateBulletShield()
    {
        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * 360f / numBullets;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Instantiate(bulletPrefab, transform.position, rotation);
        }
    }
    private void Update()
    {
        // Rotate the enemy and its bullets
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }
}
