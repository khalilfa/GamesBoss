using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float counter;
	
	void Update () {
        this.counter += Time.deltaTime;
	}
}
