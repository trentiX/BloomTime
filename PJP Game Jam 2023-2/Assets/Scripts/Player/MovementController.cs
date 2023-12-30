using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovementController : MonoBehaviour
{
    // Components
    private Rigidbody2D _rb;
    
    // Player
    [SerializeField] private float walkSpeed = 8f;
    [SerializeField] private GameObject panel;
    private const float SpeedLimiter = 0.7f;
    private float _inputHorizontal;
    private float _inputVertical;
    

    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.isOpen = true;
            Time.timeScale = 0f;

            if (panel.activeSelf == true)
            {
                panel.SetActive(false);
                Pause.isOpen = false;
                Time.timeScale = 1f;
            }
            else
            {
                Pause.isOpen = true;
                panel.SetActive(true); 
            }
        }

        if (Pause.isOpen)
        { 
            _rb.velocity = Vector2.zero; 
            return;
        }

        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _inputVertical = Input.GetAxisRaw("Vertical");
        
        if (_inputHorizontal != 0 || _inputVertical != 0)
        {
            if (_inputHorizontal != 0 && _inputVertical != 0)
            {
                _inputHorizontal *= SpeedLimiter;
                _inputVertical *= SpeedLimiter;

            }
            _rb.velocity = new Vector2(_inputHorizontal * walkSpeed, _inputVertical * walkSpeed);
        }
        else
        {
            _rb.velocity = new Vector2(0f, 0f);
        }
    }
}
