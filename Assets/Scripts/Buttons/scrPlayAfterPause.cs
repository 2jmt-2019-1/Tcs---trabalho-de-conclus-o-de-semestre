using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayAfterPause : MonoBehaviour {

    public GameObject menuPause;

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }
}
