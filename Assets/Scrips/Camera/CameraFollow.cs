﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public float posX = 7.5f;
    public float posY = 5;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start() {
        transform.position = new Vector3(transform.position.x, 0, 0);
    }

    public void SetPlayer(GameObject newPlayer) {
        this.player = newPlayer;
    }

    private void FixedUpdate() {
        FollowPlayer();
    }

    private void FollowPlayer() {
        float cameraPosX = player.transform.position.x + posX;
        float cameraPosY = player.transform.position.y + posY;
        transform.position = new Vector3(cameraPosX, cameraPosY, -10);
    }
}