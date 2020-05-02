using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : VidaBase
{

    protected override void Morir()
    {
        base.Morir();      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void InmortalOn()
    {
        //print("soy inmortal");
        isInmortal = true;
    }

    void InmortalOff()
    {
       // print("no lo soy");
        isInmortal = false;
    }
}
