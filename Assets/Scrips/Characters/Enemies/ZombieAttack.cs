using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {

    public GameObject player;
    public int damage = 25;
    public float atackTime;
    private float timeCounter;
    private Animator animator;


    private void Awake() {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.timeCounter = 0;
        this.animator = this.gameObject.GetComponent<Animator>();
    }

    void Update () {
        Attack();
        this.timeCounter += Time.deltaTime;
	}

    void Attack() {
        bool stay = this.gameObject.GetComponent<EnemyController>().stay;
        if (stay && this.timeCounter >= this.atackTime) {
            StartCoroutine("AttackCourutine");
        }
    }

    IEnumerator AttackCourutine() {
        this.animator.SetBool("attackMode", true);
        this.timeCounter = 0;
        yield return new WaitForSeconds(this.atackTime / 2);
        this.player.GetComponent<PlayerController>().GetDamage(this.damage);
        this.animator.SetBool("attackMode", false);
    }
}
