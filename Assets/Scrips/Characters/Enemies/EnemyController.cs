﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private float posicionIncial;
    public float velEnemy;
    public float movimiento = 1;
    public bool mirandoDerecha = true;

    private Animator animator;
    private Rigidbody2D rb;

    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        posicionIncial = this.transform.position.x;
    }

    void FixedUpdate() {
        Movimiento();
    }

    void Movimiento() {
        if (mirandoDerecha) {
            if (this.transform.position.x > posicionIncial + movimiento) {
                mirandoDerecha = false;
                this.transform.localScale = new Vector3(-1, 1, 1);
            } else {
                this.rb.velocity = new Vector3(velEnemy, rb.velocity.y, 0);
                animator.SetFloat("velX", velEnemy);
            }
        } else {
            if (this.transform.position.x < posicionIncial - movimiento) {
                mirandoDerecha = true;
                this.transform.localScale = new Vector3(1, 1, 1);
            } else {
                this.rb.velocity = new Vector3(-velEnemy, rb.velocity.y, 0);
                animator.SetFloat("velX", velEnemy);
            }
        }
    }
}