using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrPlayLevel1 : MonoBehaviour {

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
}
