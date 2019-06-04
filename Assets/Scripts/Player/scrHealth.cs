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

	void Start () {
        Player = GetComponent<scrPlayer>();
        Vida.text = "X " + Vidas;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Incinerador")
        {
            DeathMusic.Play();
            Music.Stop();
            Vida.text = "X " + 0;
            Death.Play();
            Player.enabled = false;
            Morte.SetActive(true);
        }
        if (quem.gameObject.tag == "Prensa")
        {
            if (Vidas <= 0)
            {
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

    IEnumerator Invencibilidade()
    {
        semdano = true;
        Animador.color = Dano[0];
        yield return new WaitForSeconds(1);
        Animador.color = Dano[1];
        semdano = false;
    }

}
