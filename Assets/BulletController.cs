using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject owner;
    public float velocity = 5;
    public int rightPosition = 1;
    public int damage = 10;

    private Rigidbody2D rb2d;

    private void Awake() {
        this.rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        Movimiento();	
	}

    void Movimiento() {
        if (owner.gameObject.tag == "Player") {
            this.rb2d.AddForce(new Vector2(this.velocity * rightPosition, 0));
        }
    }

    public void SetState(GameObject owner) {
        this.owner = owner;
        this.rightPosition = owner.GetComponent<PlayerController>().rightPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GiveDamage(collision);
    }

    private void Destroy() {
        DestroyImmediate(this.gameObject);
    }

    private void GiveDamage(Collider2D collision) {
        if(collision.tag == "Enemy" && owner.tag == "Player") {
            collision.GetComponent<EnemyController>().GetDamage(this.damage);
            Destroy();
        } else if (collision.tag == "Player" && owner.tag == "Enemy") {
            collision.GetComponent<PlayerController>().GetDamage(this.damage);
            Destroy();
        }
    }
}
