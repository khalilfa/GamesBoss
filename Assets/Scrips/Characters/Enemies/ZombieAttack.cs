using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {

    public GameObject player;
    public int damage = 25;
    public float atackTime;
    private float timeCounter;
    private Animator animator;

    private AudioSource audioSource;
    public AudioClip zombieAttackAudio;
    public AudioClip zombieMovementAudio;


    private void Awake() {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.timeCounter = 0;
        this.animator = this.gameObject.GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        Attack();
        this.timeCounter += Time.deltaTime;
        //MovementAudio();
	}

    void MovementAudio() {
        bool stay = this.GetComponent<EnemyController>().stay;
        if (!stay) {
            this.GetComponent<AudioSource>().clip = this.zombieMovementAudio;
            this.GetComponent<AudioSource>().Play();
        } else {
            this.GetComponent<AudioSource>().Stop();
        }
    }

    void Attack() {
        bool stay = this.gameObject.GetComponent<EnemyController>().stay;
        if (stay && this.timeCounter >= this.atackTime) {
            StartCoroutine("AttackCourutine");
        }
    }

    void AttackSound() {
        this.GetComponent<AudioSource>().clip = this.zombieAttackAudio;
        this.GetComponent<AudioSource>().Play();
    }

    IEnumerator AttackCourutine() {
        //AttackSound();
        this.animator.SetBool("attackMode", true);
        this.timeCounter = 0;
        yield return new WaitForSeconds(this.atackTime / 2);
        this.player.GetComponent<PlayerController>().GetDamage(this.damage);
        this.animator.SetBool("attackMode", false);
    }
}
