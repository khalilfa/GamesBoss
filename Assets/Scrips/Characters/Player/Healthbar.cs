using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{


    public Image health;
    private GameObject player;

    private float hp;
    public float maxHp;
    public float dieSeconds;


    void Start(){
        hp = maxHp;
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        Die();
    }

    void Die() {
        if (hp == 0) {
            StartCoroutine("RestartLevel");
        }
    }

    IEnumerator RestartLevel() {
        this.player.GetComponent<PlayerController>().Die();
        yield return new WaitForSeconds(this.dieSeconds);
        Application.LoadLevel(Application.loadedLevel);
    }



    public void TakeDamage(float amount) // funcion para restar vida, se debe agregar ej cuando el personaje recibe bala o choca con enemigo.
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);  //establece que el hp no puede ser menos a 0 o mayor a 100
        health.transform.localScale = new Vector2(hp / maxHp, 1); // funcion para restar vida, se debe agregar ej cuando el personaje recibe bala o choca con enemigo.
    }

}
