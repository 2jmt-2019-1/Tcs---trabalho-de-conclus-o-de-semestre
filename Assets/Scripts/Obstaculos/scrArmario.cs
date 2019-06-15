using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrArmario : MonoBehaviour {


    Animator AnimArm;
    public bool entrou;
    scrPlayer Play;
    public GameObject Player;
    public bool invisivel = false;

	// Use this for initialization
	void Start () {
        Play = Player.GetComponentInChildren<scrPlayer>();
        AnimArm = GetComponent<Animator>();
	}


	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) && invisivel)
        {
            invisivel = false;
            Play.gameObject.SetActive(true);
            AnimArm.SetBool("Aberto", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !invisivel && entrou)
        {
            invisivel = true;
            Play.gameObject.SetActive(false);
            AnimArm.SetBool("Aberto", true);
        }
	}

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            entrou = true;
        }
    }

    void OnTriggerExit2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            entrou = false;
        }
    }
}
