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
        this.rb2d.AddRelativeForce(new Vector2(this.velocity * rightPosition, 0), ForceMode2D.Impulse);
    }

    public void SetState(GameObject owner) {
        this.owner = owner;
        if(owner.tag == "Player") {
            this.rightPosition = owner.GetComponent<PlayerController>().rightPosition;
        } else if(owner.tag == "Enemy") {
            this.rightPosition = owner.GetComponent<EnemyController>().rightPosition;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GiveDamage(collision);
    }

    private void Destroy() {
        Destroy(this.gameObject);
    }

    private void GiveDamage(Collider2D collision) {
        if(collision.tag == "Enemy" && owner.tag == "Player") {
            collision.GetComponent<EnemyDefenseController>().GetDamage(this.damage);
            Destroy();
        } else if (collision.tag == "Player" && owner.tag == "Enemy") {
            collision.GetComponent<PlayerController>().GetDamage(this.damage);
            Destroy();
        }
    }
}
