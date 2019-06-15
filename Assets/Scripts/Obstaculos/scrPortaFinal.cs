using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrPortaFinal : MonoBehaviour {

    bool entrou;
    bool aberto;
    public bool Aberta;
    public Animator AnimPorta;
    public GameObject Interruput;
    scrButtonlvl2 Liga;

    void Start()
    {
        Liga = Interruput.GetComponent<scrButtonlvl2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entrou && aberto && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("CutScene2");
        }

        if (Liga.AnimeOpen)
        {
            AnimPorta.SetBool("Aberto", true);
            aberto = true;
        }
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
}
