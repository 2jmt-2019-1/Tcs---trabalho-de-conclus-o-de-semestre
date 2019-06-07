using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerCam : MonoBehaviour {

    GameObject PlayerSet;

	// Use this for initialization
	void Start () {
        PlayerSet = GameObject.FindGameObjectWithTag("PlayerSet");
        PlayerSet.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
