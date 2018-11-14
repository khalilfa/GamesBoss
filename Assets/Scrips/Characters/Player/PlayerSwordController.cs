using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordController : MonoBehaviour {

    public Transform playerGun;
    public GameObject camera;

    private void Start() {
        this.camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void FixedUpdate () {
        SetGun();
	}

    void SetGun() {
        if (Input.GetKey(KeyCode.Alpha2)) {
            GameObject newPlayer = (Instantiate(playerGun, transform.position, transform.rotation)).gameObject;
            this.camera.GetComponent<CameraFollow>().SetPlayer(newPlayer);
            Destroy(this.gameObject);
        }
    }
}
