using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPortaAberta : MonoBehaviour {

    public bool Aberta;
    public Animator AnimPorta;
    public GameObject Interruput;
    scrOpenDoor Liga;

	void Start () {
        Liga = Interruput.GetComponent<scrOpenDoor>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Liga.AnimeOpen)
        {
            AnimPorta.SetBool("Abrindo", true);
        }
	}

    void Aberto()
    {
        AnimPorta.SetBool("Aberto", true);
    }
}
