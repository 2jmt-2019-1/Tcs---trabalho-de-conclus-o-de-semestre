using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour {

    public GameObject Range;
    bool check;
    public float TempDesligado;
    public float TempLigado;
    public float tempo;
    float inverso;
    Animator AnimCam;

    void Start() {
        AnimCam = GetComponent<Animator>();
        tempo = TempLigado;
        inverso = TempDesligado * -1;
    }
	
	void Update () {
        tempo -= Time.deltaTime;
        if(tempo <= 0)
        {
            check = true;
        }
        else
        {
            check = false;
        }
        if(tempo <= inverso)
        {
            tempo = TempLigado;
        }
        if(check)
        {
            Range.SetActive(false);
            AnimCam.SetBool("Ativada", false);
        }
        if (!check)
        {
            Range.SetActive(true);
            AnimCam.SetBool("Ativada", true);
        }
    }

    IEnumerator LigandoEDesligando()
    {
        check = true;
        yield return new WaitForSeconds(TempDesligado);
        check = false;
        yield return new WaitForSeconds(TempLigado);
    }
}
