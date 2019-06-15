using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRobot : MonoBehaviour {

    bool invertido;
    scrRevive revive;
    GameObject Robo;
    scrHealth Player;
    Animator AnimRobot;
    public float tempo;
    public int direção;
    public float velocidade;
    public float limitright;
    public float limitleft;

    // Use this for initialization
    void Start() {
        AnimRobot = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<scrHealth>();
        Robo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {

        bool pego = Player.pegou;

        if (pego)
        {
            AnimRobot.SetBool("Pegou", true);
            if (Robo.transform.position.x <= gameObject.transform.position.x && !invertido)
            {
                invertido = true;
                var xtso = gameObject.transform.localScale;
                xtso.x *= -1;
                gameObject.transform.localScale = xtso;
            }
        }
        else
        {
            AnimRobot.SetBool("Pegou", false);
            var pto = transform.position;
            pto.x += direção * velocidade * Time.deltaTime;
            transform.position = pto;
            if (pto.x >= limitright)
            {
                StartCoroutine(RevertendoDireita());
            }

            if (pto.x <= limitleft)
            {
                StartCoroutine(RevertendoEsquerda());
            }
        }
    }
    public IEnumerator RevertendoDireita()
    {
        direção = 0;
        yield return new WaitForSeconds(tempo);
        direção = -1;
    }

    public IEnumerator RevertendoEsquerda()
    {
        direção = 0;
        yield return new WaitForSeconds(tempo);
        direção = 1;
    }
}
