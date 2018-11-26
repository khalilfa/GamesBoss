using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;
    public int rightPosition = 1;
    public int life = 100;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    private bool doubleJump;

    public GameObject healthbar;
    public int monedas = 0;

    private AudioSource audioPlayer;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update() {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (grounded) {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (grounded) {
                jump = true;
                doubleJump = true;
            } else if (doubleJump) {
                jump = true;
                doubleJump = false;
            }
        }
    }

    void FixedUpdate() {

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

        if (jump) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
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

    public void SumarVida()
    {
        healthbar.GetComponent<Healthbar>().TakeDamage(-5);
    }

    public void SumarMoneda()
    {
        monedas++;
    }

    public void GetDamage(int damage) {
        healthbar.GetComponent<Healthbar>().TakeDamage(damage);
    }



}


