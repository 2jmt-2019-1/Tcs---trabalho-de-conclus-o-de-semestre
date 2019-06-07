using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEsteira : MonoBehaviour {

    public GameObject Player;
    public float Velocidade;
    public int Direção;
    scrHealth Health;

	void Start () {
        Health = Player.GetComponent<scrHealth>();
	}

    public void OnCollisionStay2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Player" && Health.Vidas >= 1)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(Velocidade * Direção, 0f), ForceMode2D.Force);
        }
    }
}
