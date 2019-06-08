using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEsteira : MonoBehaviour {

    bool empurrando;
    public GameObject Player;
    public float Velocidade;
    public int Direção;
    scrHealth Health;

	void Start () {
        Health = Player.GetComponent<scrHealth>();
	}

    void FixedUpdate()
    {
        if (empurrando)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(Velocidade * Direção, 0f), ForceMode2D.Force);
        }
    }

    public void OnCollisionEnter2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Player" && Health.Vidas >= 1)
        {
            empurrando = true;
        }
    }
    public void OnCollisionExit2D(Collision2D quem)
    {
        if (quem.gameObject.tag == "Player" && Health.Vidas >= 1)
        {
            empurrando = false;
        }
    }
}
