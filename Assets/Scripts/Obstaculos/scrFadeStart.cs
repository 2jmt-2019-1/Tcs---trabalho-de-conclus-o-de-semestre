using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrFadeStart : MonoBehaviour {

    Text textVidas;
    Image telaPreta;
    public Color[] cores;
    Image Vida;


    float taxaTransicao = 0f;
    void Start()
    {
        telaPreta = GameObject.FindGameObjectWithTag("Transição").GetComponent<Image>();
        textVidas = GameObject.FindGameObjectWithTag("VidaText").GetComponent<Text>();
        Vida = GameObject.FindGameObjectWithTag("VidaImage").GetComponent<Image>();
        StartCoroutine(Faden());
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

    public void fadeOut()
    {
        taxaTransicao = 0f;
        InvokeRepeating("Clarear", 0f, 0.05f);
    }

    public IEnumerator Faden()
    {
        yield return new WaitForSeconds(0.02f);
        fadeOut();
        Vida.enabled = true;
        textVidas.enabled = true;
    }
}
