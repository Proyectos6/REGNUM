using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dañar : MonoBehaviour
{

    EnemyVida VIDA;
    public GameObject Hacha1H;
    public GameObject Hacha2H;

    float Daño;
    float Impulse;

    public float DañoAxe1H;
    public float DañoAxe2H;
    public float ImpulseAxe1H;
    public float ImpulseAxe2H;
    void Start()
    {
        
    }
    void Update()
    {
        if (Hacha1H.active)
        {
            Daño = DañoAxe1H;
            Impulse = ImpulseAxe1H;
        }
        if (Hacha2H.active)
        {
            Daño = DañoAxe2H;
            Impulse = ImpulseAxe2H;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        
    }
}
