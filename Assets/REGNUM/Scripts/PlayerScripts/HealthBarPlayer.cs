using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Image imaVida;
    Movimiento vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (vida.vida > 25)
        {
            imaVida.color = Color.green;
        }
        if (vida.vida < 25)
        {
            imaVida.color = Color.white;
        }
    }
}
