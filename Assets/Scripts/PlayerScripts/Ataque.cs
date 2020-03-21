using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    bool OnRange;
    float tiempoPegando;
    GameObject Enemy;

    void Start()
    {
                
    }
    void Update()
    {
        if (OnRange)
        {
            OnRange = false;
        }

    }
}
