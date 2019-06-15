using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrRevive : MonoBehaviour {

    int nivel;
    public GameObject Morte;

    private void Start()
    {
    }
    private void Update()
    {
        nivel = SceneManager.GetActiveScene().buildIndex;
    }

    public void reviver()
    {
        SceneManager.LoadScene(nivel);
    }
    IEnumerator rev()
    {
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene(nivel);
    }
}
