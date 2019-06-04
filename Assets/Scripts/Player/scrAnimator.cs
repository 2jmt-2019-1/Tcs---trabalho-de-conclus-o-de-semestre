using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrAnimator : MonoBehaviour {

    GameObject PlayerWithScr;
    scrPlayer Player;
    Animator AnimPlayer;
    public bool olhandoDireita;
    SpriteRenderer spriteRenderer;

	void Start () {
        AnimPlayer = GetComponent<Animator>();
        PlayerWithScr = GameObject.Find("Player");
        Player = PlayerWithScr.GetComponent<scrPlayer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.EixoX == 0)
        {
            AnimPlayer.SetInteger("Walking", 0);
        }
        if (Player.EixoX != 0)
        {
            AnimPlayer.SetInteger("Walking", 1);
        }
        if (Player.EixoX < 0 && olhandoDireita)
        {
            Virar();
        }
        if (Player.EixoX > 0 && !olhandoDireita)
        {
            Virar();
        }
        AnimPlayer.SetFloat("VelY", Player.VeloY);
	}

    void LateUpdate()
    {
        AnimPlayer.SetBool("NoChao", Player.NoChao);
    }

    public void Virar()
    {
        olhandoDireita = !olhandoDireita;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
