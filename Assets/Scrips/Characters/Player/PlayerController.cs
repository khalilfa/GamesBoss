using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;
    public int rightPosition = 1;
    public GameObject feet;

    private Rigidbody2D rb2d;
    private Animator anim;
    public bool blockMovement;

    public GameObject healthbar;
    public int monedas = 0;

    private AudioSource audioPlayer;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        this.blockMovement = false;
    }

    void Jump() {
        if (!this.blockMovement) {
            float jump = Input.GetAxis("Vertical");

            if (jump >= 0.1f && this.grounded) {
                this.grounded = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                this.feet.GetComponent<AudioSource>().Play();
            }
        }   
    }

    public void Die() {
        this.anim.SetBool("Die", true);
        this.blockMovement = true;
    }

    public bool HasCoins(int cant) {
        return this.monedas >= cant;
    }

    void FixedUpdate() {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        Jump();
        Movement();
    }

    void Movement() {
        if (!this.blockMovement) {
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;

            if (grounded) {
                rb2d.velocity = fixedVelocity;
            }

            float h = Input.GetAxis("Horizontal");

            rb2d.AddForce(Vector2.right * speed * h);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            if (h > 0.1f) {
                transform.localScale = new Vector3(1f, 1f, 1f);
                this.rightPosition = 1;
            }

            if (h < -0.1f) {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                this.rightPosition = -1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)  // SI TOCA LOS PINCHOS PIERDA 5 DE VIDA ---- SI SE CAE DE PANTALLA SE REINICIA LA EL JUEGO- ACORDARSE TILDAS OPCION "IS TRIGGER" EN LOS PINCHOS.
    {
        if (col.gameObject.tag == "Pinchos" )
        {

            healthbar.GetComponent<Healthbar>().TakeDamage(5);
        }

        if (col.gameObject.tag == "Life")
        {

            healthbar.GetComponent<Healthbar>().TakeDamage(-15);
        }

        if (col.gameObject.tag == "Muerte")
        {
            Application.LoadLevel(Application.loadedLevel);
           
        }

    }

    public void Impulso() {
        rb2d.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
        rb2d.AddForce(Vector2.right * 100, ForceMode2D.Impulse);
    }

    public void SumarVida()
    {
        healthbar.GetComponent<Healthbar>().TakeDamage(-20);
    }

    public void SumarMoneda()
    {
        monedas++;
    }

    public void GetDamage(int damage) {
        healthbar.GetComponent<Healthbar>().TakeDamage(damage);
    }



}


