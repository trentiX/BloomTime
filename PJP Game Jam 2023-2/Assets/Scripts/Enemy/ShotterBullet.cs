using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotterBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
