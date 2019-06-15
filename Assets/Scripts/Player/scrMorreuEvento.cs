using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrMorreuEvento : MonoBehaviour {

    Animator AnimPlayer;

    void Start()
    {
        AnimPlayer = GetComponent<Animator>();
    }

    void morto()
    {
        AnimPlayer.SetBool("Morto", true);
    }
}
