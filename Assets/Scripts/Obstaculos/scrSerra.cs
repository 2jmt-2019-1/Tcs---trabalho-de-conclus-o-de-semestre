using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSerra : MonoBehaviour {

    int angulo = 360;
    float velocidadeRot = 1.5f;

    public float velocidade;

    public float LimitDireita;
    public float LimitEsquerda;

    int direção;
    public bool DireçãoDireita;

	void Start () {
		
	}
	void Update () {
        if (DireçãoDireita)
        {
            direção = 1;
        }
        else
        {
            direção = -1;
        }

        var pto = transform.position;
        pto.x += (velocidade * direção * Time.deltaTime);
        transform.position = pto;

        if (transform.position.x >= LimitDireita)
        {
            DireçãoDireita = !DireçãoDireita;
        }
        if (transform.position.x <= LimitEsquerda)
        {
            DireçãoDireita = !DireçãoDireita;
        }

        Quaternion rotacao = transform.rotation;
        float z = rotacao.eulerAngles.z;
        z += direção * angulo * velocidadeRot * Time.deltaTime;
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;
	}
}
