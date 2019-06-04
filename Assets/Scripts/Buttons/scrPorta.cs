using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrPorta : MonoBehaviour {

    public Transform PortaInicio;
    public Transform PortaAlvo;
    bool contatoPlayer = false;
    public GameObject Player;
    public Text textVidas;
    public Image telaPreta;
    public Color[] cores;
    public Image Vida;


    float taxaTransicao = 0f;
    void Update()
    {
        if (contatoPlayer && Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            StartCoroutine(FadeIn());
        }

    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            contatoPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            contatoPlayer = false;
        }
    }

    public void Clarear()
    {
        if (taxaTransicao >= 1f)
        {
            CancelInvoke("Clarear");
        }
        telaPreta.color = Color.Lerp(cores[1], cores[0], taxaTransicao);
        taxaTransicao += 0.05f;
    }

    public void Escurecer()
    {
        if (taxaTransicao >= 1f)
        {
            CancelInvoke("Escurecer");

        }
        telaPreta.color = Color.Lerp(cores[0], cores[1], taxaTransicao);
        taxaTransicao += 0.05f;

    }
    public void fadeIn()
    {
        taxaTransicao = 0f;
        InvokeRepeating("Escurecer", 0f, 0.02f);
    }

    public void fadeOut()
    {
        taxaTransicao = 0f;
        InvokeRepeating("Clarear", 0f, 0.05f);
    }

    public IEnumerator FadeIn()
    {
        Vida.enabled = false;
        textVidas.enabled = false;
        fadeIn();
        yield return new WaitForSeconds(1);
        Player.transform.position = PortaAlvo.transform.position;
        yield return new WaitForSeconds(1);
        fadeOut();
        Vida.enabled = true;
        textVidas.enabled = true;
    }
}
