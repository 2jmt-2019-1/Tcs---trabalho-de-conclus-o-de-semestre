using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrStepAndar : MonoBehaviour {

    public GameObject Andar;
    bool Entrou;
    SpriteRenderer SpriteRe;
    public Sprite[] button;
    public GameObject erro;

	// Use this for initialization
	void Start () {
        SpriteRe = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Entrou && Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Aparecendo());
        }
	}

    void OnTriggerExit2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            Entrou = false;
        }
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            Entrou = true;
        }
    }

    IEnumerator Aparecendo()
    {
        SpriteRe.sprite = button[0];
        Andar.SetActive(true);
        erro.SetActive(true);
        yield return new WaitForSeconds(11);
        erro.SetActive(false);
        Andar.SetActive(false);
        SpriteRe.sprite = button[1];
    }
}
