using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosController : MonoBehaviour {

    public int damage;
    public float timeToDamage;
    public GameObject playerFeet;
    public GameObject player;
    private GameObject timer;

    private void Awake() {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.playerFeet = GameObject.FindGameObjectWithTag("Feet");
        this.timer = GameObject.FindGameObjectWithTag("Timer");
    }

    private void FixedUpdate() {
        if (this.GetComponent<BoxCollider2D>().IsTouching(this.playerFeet.GetComponent<CircleCollider2D>())) {
            if (this.timer.GetComponent<Timer>().counter > this.timeToDamage) {
                this.player.GetComponent<PlayerController>().GetDamage(this.damage);
                this.timer.GetComponent<Timer>().counter = 0;
            }
        }
    }
}
