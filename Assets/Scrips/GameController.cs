using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {




    private AudioSource musicPlayer;


	// Use this for initialization
	void Start () {
        musicPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        musicPlayer.Play();
	}
}
