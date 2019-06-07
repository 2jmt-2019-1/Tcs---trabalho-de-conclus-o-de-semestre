using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrHealth : MonoBehaviour {

    public Text Vida;
    public int Vidas;
    public GameObject Morte;
    scrPlayer Player;
    public bool Parado;
    public AudioSource DeathMusic;
    public AudioSource Music;
    public AudioSource Hit;
    public AudioSource Death;
    GameObject[] incinerador;
    scrIncinerador[] incinerar;
    public SpriteRenderer Animador;
    public Color[] Dano;
    bool semdano;
    Rigidbody2D rigid;

	void Start () {
        Player = GetComponent<scrPlayer>();
        Vida.text = "X " + Vidas;
        rigid = Player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Serra")
        {
            if (Vidas <= 1)
            {
                rigid.velocity = new Vector2(0, 0);
                Vida.text = "X " + 0;
                DeathMusic.Play();
                Music.Stop();
                Death.Play();
                Player.enabled = false;
                Morte.SetActive(true);
            }
            else
            {
                if (!semdano)
                {
                    StartCoroutine(Invencibilidade());
                    Hit.Play();
                    Vidas--;
                    Vida.text = "X " + Vidas;
                }
            }
        }
        
        if (quem.gameObject.tag == "Incinerador")
        {
            rigid.velocity = new Vector2(0, 0);
            DeathMusic.Play();
            Music.Stop();
            Vida.text = "X " + 0;
            Death.Play();
            Player.enabled = false;
            Morte.SetActive(true);
        }
        if (quem.gameObject.tag == "Prensa")
        {
            if (Vidas <= 1)
            {
                rigid.velocity = new Vector2(0, 0);
                Vidas--;
                Vida.text = "X " + 0;
                DeathMusic.Play();
                Music.Stop();
                Death.Play();
                Player.enabled = false;
                Morte.SetActive(true);
            }
            else
            {
                if (!semdano)
                {
                    StartCoroutine(Invencibilidade());
                    Hit.Play();
                    Vidas--;
                    Vida.text = "X " + Vidas;
                }
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "ExtraHealth")
        {
            Vidas++;
            Vida.text = "X " + Vidas;
        }
    }

    IEnumerator Invencibilidade()
    {
        semdano = true;
        Animador.color = Dano[0];
        yield return new WaitForSeconds(1);
        Animador.color = Dano[1];
        semdano = false;
    }

}
