using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private float posicionIncial;
    public float velEnemy;
    public float movimiento = 1;
    public int rightPosition = 1;
    public float visualRadius;
    public GameObject player;
    public bool shootOn = false;
    public bool stay = false;
    public float stayDistance = 2;

    private Animator animator;
    private Rigidbody2D rb;

    void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        posicionIncial = this.transform.position.x;
    }

    void FixedUpdate() {
        Movimiento();
        InVisualRaius();
        Follow();
        Stay();
    }

    

    void InVisualRaius() {
        float distance = Vector2.Distance(this.player.transform.position, transform.position);
        Vector3 target = this.player.transform.position;
        if (distance < this.visualRadius) {
            this.shootOn = true;
        }
    }

    void Stay() {
        float distance = Vector2.Distance(this.player.transform.position, transform.position);
        if (distance < this.stayDistance) {
            this.stay = true;
            Vector3 velocity = new Vector3(0, rb.velocity.y, 0);
            this.rb.velocity = velocity;
            animator.SetFloat("velX", 0);
        } else {
            this.stay = false;
        }
    }

    void Follow() {
        if (this.shootOn && !this.stay) {
            Vector3 playerPosition = this.player.transform.position;
            if (playerPosition.x < transform.position.x) {
                this.rightPosition = -1;
                Vector3 newScale = new Vector3(-1, 1, 1);
                this.transform.localScale = newScale;

                Vector3 velocity = new Vector3(-velEnemy, rb.velocity.y, 0);
                this.rb.velocity = velocity;
                animator.SetFloat("velX", velEnemy);
            } else {
                rightPosition = 1;
                Vector3 newScale = new Vector3(1, 1, 1);
                this.transform.localScale = newScale;

                Vector3 velocity = new Vector3(velEnemy, rb.velocity.y, 0);
                this.rb.velocity = velocity;
                animator.SetFloat("velX", velEnemy);
            }
        }
    
    }

    void Movimiento() {
        if (!this.shootOn && !this.stay) {
            if (rightPosition == 1) {
                if (this.transform.position.x > posicionIncial + movimiento) {
                    rightPosition = -1;
                    Vector3 newScale = new Vector3(-1, 1, 1);
                    this.transform.localScale = newScale;
                } else {
                    Vector3 velocity = new Vector3(velEnemy, rb.velocity.y, 0);
                    this.rb.velocity = velocity;
                    animator.SetFloat("velX", velEnemy);
                }
            } else {
                if (this.transform.position.x < posicionIncial - movimiento) {
                    rightPosition = 1;
                    Vector3 newScale = new Vector3(1, 1, 1);
                    this.transform.localScale = newScale;
                } else {
                    Vector3 velocity = new Vector3(-velEnemy, rb.velocity.y, 0);
                    this.rb.velocity = velocity;
                    animator.SetFloat("velX", velEnemy);
                }
            }
        }
    }
}