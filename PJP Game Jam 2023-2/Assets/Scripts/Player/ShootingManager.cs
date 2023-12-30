using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Rigidbody2D playerRB;
    
    private Vector2 mousePosition;

    private void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Pause.isOpen)
        { 
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = mousePosition - playerRB.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        playerRB.rotation = aimAngle;
    }
}
