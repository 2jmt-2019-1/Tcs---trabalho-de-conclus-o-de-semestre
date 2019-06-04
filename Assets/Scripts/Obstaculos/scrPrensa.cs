using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPrensa : MonoBehaviour {

    public bool Descer;
    public float Subindo;
    public float Descendo;
    public float LimiteCima;
    public float LimiteBaixo;

    Vector3 vpto;


	void Start () {
	}
	void Update () {
        if (gameObject.transform.position.y <= LimiteBaixo)
        {
            Descer = false;
        }
        if (gameObject.transform.position.y >= LimiteCima)
        {
            Descer = true;
        }
        if (Descer == false)
        {
            vpto = gameObject.transform.position;
            vpto.y += Subindo;
            gameObject.transform.position = vpto;
        }
        if (Descer == true)
        {
            vpto = gameObject.transform.position;
            vpto.y -= Descendo;
            gameObject.transform.position = vpto;
        }
	}

    public void OnCollisionEnter2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {

        }
    }
}
