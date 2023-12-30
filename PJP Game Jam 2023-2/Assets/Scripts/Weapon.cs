using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private float fireForce = 20f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoints[0].position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoints[0].up * fireForce,
            ForceMode2D.Impulse);
    }

    public void MultipleFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoints[0].position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoints[0].up * fireForce,
            ForceMode2D.Impulse);
        
        GameObject bullet2 = Instantiate(bulletPrefab, firePoints[1].position, Quaternion.identity);
        bullet2.GetComponent<Rigidbody2D>().AddForce(firePoints[1].up * fireForce,
            ForceMode2D.Impulse);
        
        GameObject bullet3 = Instantiate(bulletPrefab, firePoints[2].position, Quaternion.identity);
        bullet3.GetComponent<Rigidbody2D>().AddForce(firePoints[2].up * fireForce,
            ForceMode2D.Impulse);
    }
}
