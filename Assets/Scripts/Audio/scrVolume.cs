using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrVolume : MonoBehaviour {

    public Slider Music;
    public AudioSource Volume;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Volume.volume = Music.value;

        
	}
}
