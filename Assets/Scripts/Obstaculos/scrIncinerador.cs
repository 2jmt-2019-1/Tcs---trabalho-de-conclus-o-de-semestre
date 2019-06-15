using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrIncinerador : MonoBehaviour {

    SpriteRenderer sp;
    public Sprite[] inc;
    public Light luzIncinerador;
    GameObject PlayerP;
    scrHealth Vida;
    public bool Morreu;

	void Start () {
		PlayerP = GameObject.Find("Player");
        Vida = PlayerP.GetComponent<scrHealth>();
        sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (sp.sprite == inc[0])
        {
            luzIncinerador.intensity = 5.6f;
        }
        if (sp.sprite == inc[1])
        {
            luzIncinerador.intensity = 6.6f;
        }
        if (sp.sprite == inc[2])
        {
            luzIncinerador.intensity = 7.6f;
        }
        if (sp.sprite == inc[3])
        {
            luzIncinerador.intensity = 8.6f;
        }
        if (sp.sprite == inc[4])
        {
            luzIncinerador.intensity = 9.6f;
        }
        if (sp.sprite == inc[5])
        {
            luzIncinerador.intensity = 6.6f;
        }
        if (sp.sprite == inc[6])
        {
            luzIncinerador.intensity = 3.6f;
        }

	}

    void OnCollisionEnter2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            Morreu = true;
        }
    }
}
