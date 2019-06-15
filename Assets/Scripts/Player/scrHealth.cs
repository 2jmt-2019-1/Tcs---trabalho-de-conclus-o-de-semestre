using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrHealth : MonoBehaviour {

    public bool checkpego;
    public bool pegou;
    public Text Vida;
    public int Vidas;
    public GameObject Morte;
    scrPlayer Player;
    public bool Parado;
    public AudioSource GotMusic;
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
    Animator play;

	void Start () {
        Player = GetComponent<scrPlayer>();
        Vida.text = "X " + Vidas;
        rigid = Player.GetComponent<Rigidbody2D>();
        play = GameObject.FindGameObjectWithTag("Animador").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (checkpego)
        {
            pegou = false;
            checkpego = false;
        }
	}

    void OnCollisionEnter2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Serra")
        {
            if (Vidas <= 1)
            {
                morte();
            }
            else
            {
                if (!semdano)
                {
                    dano();
                }
            }
        }
        
        if (quem.gameObject.tag == "Incinerador")
        {
            morte();
        }
        if (quem.gameObject.tag == "Prensa")
        {
            if (Vidas <= 1)
            {
                morte();
            }
            else
            {
                if (!semdano)
                {
                    dano();
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
        if (quem.gameObject.tag == "RobotRange")
        {
            rigid.velocity = new Vector2(0, 0);
            GotMusic.Play();
            Music.Stop();
            Vida.text = "X " + 0;
            DeathMusic.Play();
            Player.enabled = false;
            Morte.SetActive(true);
            pegou = true;
        }
    }

    void dano()
    {
        StartCoroutine(Invencibilidade());
        Hit.Play();
        Vidas--;
        Vida.text = "X " + Vidas;
    }

    void morte()
    {
        Vidas--;
        rigid.velocity = new Vector2(0, 0);
        DeathMusic.Play();
        Music.Stop();
        Vida.text = "X " + 0;
        Death.Play();
        Player.enabled = false;
        Morte.SetActive(true);
        play.SetBool("Morrendo", true);
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
