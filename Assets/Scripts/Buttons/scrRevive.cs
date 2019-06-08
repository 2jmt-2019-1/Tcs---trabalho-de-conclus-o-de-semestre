using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrRevive : MonoBehaviour {

    scrExtraHealth[] Vidas;
    public GameObject Morte;

	
	// Update is called once per frame
    void Start()    {
        Vidas = GetComponentsInChildren<scrExtraHealth>();
    }
    public void Respawn()
    {
        for (int i = 0; i < Vidas.Length; i++)
        {
            Vidas[i].gameObject.SetActive(true);
        }
        var player = GameObject.FindGameObjectWithTag("Player");
        var health = player.GetComponent<scrHealth>();
        var move = player.GetComponent<scrPlayer>();
        var respawn = GameObject.FindGameObjectWithTag("Respawn");
        move.enabled = true;
        health.DeathMusic.Stop();
        health.Music.Play();
        Morte.SetActive(false);
        health.Death.Stop();
        player.transform.position = respawn.transform.position;
        health.Vidas = 5;
        health.Vida.text = "X " + health.Vidas;
    }
}
