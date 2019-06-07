using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scrPortaAberta : MonoBehaviour {

    public GameObject Player;
    public Text textVidas;
    public Image telaPreta;
    public Color[] cores;
    public Image Vida;
    float taxaTransicao = 0f;

    public float AxisY;
    public float AxisX;
    bool entrou;
    bool aberto;
    public bool Aberta;
    public Animator AnimPorta;
    public GameObject Interruput;
    scrOpenDoor Liga;
    public Color[] Fades;

	void Start () {
        Liga = Interruput.GetComponent<scrOpenDoor>();
	}
	
	// Update is called once per frame
	void Update () {
        if (entrou && aberto && Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Fade());
        }

        if (Liga.AnimeOpen)
        {
            AnimPorta.SetBool("Abrindo", true);
        }
	}

    void Aberto()
    {
        AnimPorta.SetBool("Aberto", true);
        aberto = true;
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

    IEnumerator Fade()
    {
        Vida.enabled = false;
        textVidas.enabled = false;
        fadeIn();
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector3(AxisX, AxisY, Player.transform.position.z);
        SceneManager.LoadScene("Level2");
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

    public void Clarear()
    {
        if (taxaTransicao >= 1f)
        {
            CancelInvoke("Clarear");
        }
        telaPreta.color = Color.Lerp(cores[1], cores[0], taxaTransicao);
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

}
