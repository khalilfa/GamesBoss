using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

    public GameObject enemy;
    private float positionY;
    private float hp;
    public float maxHp;
    public GameObject green;
    public GameObject red;

    private void Start() {
        this.positionY = this.enemy.transform.position.y + 1.3f;
        this.hp = this.maxHp;
    }

    void FixedUpdate () {
        Movement();
        Dead();
	}

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        green.transform.localScale = new Vector2(hp / maxHp, green.transform.localScale.y);
    }

    private void Dead() {
        if(this.hp <= 0) {
            this.enemy.GetComponent<EnemyDefenseController>().Dead();
            Destroy(this.gameObject);
        }
    }

    private void Movement() {
        Transform enemyTransform = this.enemy.transform;
        this.transform.position = new Vector3(enemyTransform.position.x, this.positionY, 0);
    }
}
