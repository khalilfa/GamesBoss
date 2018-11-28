using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour {

    public Transform playerSword;
    public GameObject camera;
    public GameObject gun;
    public Transform bullet;
    public float shootTime;
    private float timeCounter;

    private void Start() {
        this.camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void FixedUpdate () {
        setSword();
    }

    private void Update() {
        Shoot();
        this.timeCounter += Time.deltaTime;
    }

    void setSword() {
        if (Input.GetAxis("ChangeWeapon") > 0.1) {
            GameObject newPlayer = (Instantiate(playerSword, transform.position, transform.rotation)).gameObject;
            this.camera.GetComponent<CameraFollow>().SetPlayer(newPlayer);
            Destroy(this.gameObject);
        }
    }

    void Shoot() {
        if (Input.GetAxis("Fire1") > 0.1 && this.timeCounter >= this.shootTime) {
            GameObject newBullet = (Instantiate(bullet, gun.transform.position, gun.transform.rotation)).gameObject;
            newBullet.GetComponent<BulletController>().SetState(this.gameObject);
            this.timeCounter = 0;
            this.gun.GetComponent<AudioSource>().Play();
        }
    }
}
