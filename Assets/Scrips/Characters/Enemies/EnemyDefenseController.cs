using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefenseController : MonoBehaviour {
    private Animator animator;
    public GameObject healthbar;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Dead() {
        Destroy(this.gameObject);
    }

    public void GetDamage(float damage) {
        this.healthbar.GetComponent<EnemyHealthbar>().TakeDamage(damage);
    }
}
