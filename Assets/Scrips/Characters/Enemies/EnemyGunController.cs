using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour {

    public Transform bullet;
    public GameObject gun;

    void Start () {
        InvokeRepeating("Shoot", 1, 1);
    }

    void Shoot() {
        if (this.gameObject.GetComponent<EnemyController>().shootOn) {
            GameObject newBullet = (Instantiate(bullet, this.gun.transform.position, this.gun.transform.rotation)).gameObject;
            newBullet.GetComponent<BulletController>().SetState(this.gameObject);
        }
    }
}
