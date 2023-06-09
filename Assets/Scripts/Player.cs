﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 change;
    private Rigidbody2D rb;
    private Animator animator;
    private bool dead;

    public GameObject gameover;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {        
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if(change != Vector2.zero)
        {
            rb.MovePosition(rb.position + change * speed * Time.fixedDeltaTime);
            //animator.SetFloat("moveX", change.x);
            //animator.SetFloat("moveY", change.y);
           // animator.SetBool("moving", true);
        } else
        {
          //  animator.SetBool("moving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            gameover.SetActive(true);       
            gameObject.SetActive(false);
        }
    }
}
