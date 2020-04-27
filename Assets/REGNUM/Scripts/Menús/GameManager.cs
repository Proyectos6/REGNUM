using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(paused)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
