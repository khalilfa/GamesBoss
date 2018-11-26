using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {

    public GameObject player;
    public int damage = 25;

    private void Awake() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        Attack();
	}

    void Attack() {
        bool stay = this.gameObject.GetComponent<EnemyController>().stay;
        if (stay) {
            this.player.GetComponent<PlayerController>().GetDamage(this.damage);
        }
    }
}
