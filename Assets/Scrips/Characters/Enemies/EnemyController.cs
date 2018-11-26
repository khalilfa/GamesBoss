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
    private bool shootOn = false;

    public GameObject gun;
    public Transform bullet;

    private Animator animator;
    private Rigidbody2D rb;

    void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        posicionIncial = this.transform.position.x;

        InvokeRepeating("Shoot", 1, 1);
    }

    void FixedUpdate() {
        Movimiento();
        InVisualRaius();
        Follow();
    }

    void Shoot() {
        if (this.shootOn) {
            GameObject newBullet = (Instantiate(bullet, this.gun.transform.position, this.gun.transform.rotation)).gameObject;
            newBullet.GetComponent<BulletController>().SetState(this.gameObject);
        }
    }

    void InVisualRaius() {
        float distance = Vector2.Distance(this.player.transform.position, transform.position);
        Vector3 target = this.player.transform.position;
        if (distance < this.visualRadius) {
            this.shootOn = true;
        }
    }

    void Follow() {
        if (this.shootOn) {
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
        if (!this.shootOn) {
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