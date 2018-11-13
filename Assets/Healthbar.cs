using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{


    public Image health;

    float hp, maxHp = 100f;


    void Start()
    {
        hp = maxHp;
    }

    void Update()  // SI ME SACAN LA VIDA, SE REINICIA EL JUEGO.
    {
        if (hp == 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }



    public void TakeDamage(float amount) // funcion para restar vida, se debe agregar ej cuando el personaje recibe bala o choca con enemigo.
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);  //establece que el hp no puede ser menos a 0 o mayor a 100
        health.transform.localScale = new Vector2(hp / maxHp, 1); // funcion para restar vida, se debe agregar ej cuando el personaje recibe bala o choca con enemigo.
    }

}
