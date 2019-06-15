using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrButtonlvl2 : MonoBehaviour {

    public GameObject Player;
    public GameObject Door;
    SpriteRenderer SpriteRe;
    public Sprite[] states;
    bool Entrou;
    public bool AnimeOpen;

    void Start()
    {
        SpriteRe = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Entrou && Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(PortaAbrindo());
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

    public IEnumerator PortaAbrindo()
    {
        AnimeOpen = true;
        SpriteRe.sprite = states[1];
        yield return new WaitForSeconds(3);
    }
}
