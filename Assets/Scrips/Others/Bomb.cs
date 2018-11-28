using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private Animator animator;
    public float impulseX;
    public float impulseY;
    public int damage;
    public GameObject player;

    private void Awake() {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            Impulse(collision);
            BoomSound();
            StartCoroutine("Boom");
            collision.gameObject.GetComponent<PlayerController>().GetDamage(this.damage);
        }
    }

    void Impulse(Collision2D collision) {
        StartCoroutine("BlockPlayerMovement", collision);
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb.velocity.x > 0.1) {
            rb.AddForce(Vector2.left * this.impulseX, ForceMode2D.Impulse);
        } else {
            rb.AddForce(Vector2.right * this.impulseX, ForceMode2D.Impulse);
        }

        rb.AddForce(Vector2.up * this.impulseY, ForceMode2D.Impulse);
    }

    void BoomSound() {
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    IEnumerator BlockPlayerMovement() {
        this.player.GetComponent<PlayerController>().blockMovement = true;
        yield return new WaitForSeconds(1);
        this.player.GetComponent<PlayerController>().blockMovement = false;
    }

    IEnumerator Boom() {
        this.animator.SetBool("Boom", true);
        yield return new WaitForSeconds(1.35f);
        Destroy(this.gameObject);
    }
}
