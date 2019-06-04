using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrIncinerador : MonoBehaviour {

    GameObject PlayerP;
    scrHealth Vida;
    public bool Morreu;

	void Start () {
		PlayerP = GameObject.Find("Player");
        Vida = PlayerP.GetComponent<scrHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            Morreu = true;
        }
    }
}
