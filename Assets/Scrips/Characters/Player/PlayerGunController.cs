using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour {

    public Transform playerSword;
    public GameObject camera;
    public GameObject gun;
    public Transform bullet;

    private void Start() {
        this.camera = GameObject.FindGameObjectWithTag("MainCamera");
        this.gun = GameObject.FindGameObjectWithTag("Gun");
    }

    void FixedUpdate () {
        setSword();
    }

    private void Update() {
        Shoot();
    }

    void setSword() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            GameObject newPlayer = (Instantiate(playerSword, transform.position, transform.rotation)).gameObject;
            this.camera.GetComponent<CameraFollow>().SetPlayer(newPlayer);
            Destroy(this.gameObject);
        }
    }

    void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject newBullet = (Instantiate(bullet, gun.transform.position, gun.transform.rotation)).gameObject;
            newBullet.GetComponent<BulletController>().SetState(this.gameObject);
        }
    }
}
