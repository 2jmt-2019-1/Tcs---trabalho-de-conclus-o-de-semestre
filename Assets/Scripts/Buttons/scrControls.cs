using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrControls : MonoBehaviour {

    public GameObject Menu;
    public GameObject Controls;

    public void Contros()
    {
        Menu.SetActive(false);
        Controls.SetActive(true);
    }

}
