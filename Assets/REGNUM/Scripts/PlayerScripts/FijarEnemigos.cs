using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FijarEnemigos : MonoBehaviour
{
    public GameObject[] Enemigos;
    int EnemigoFijado;
    public float MaximaDistancia = 5;
    float MasCercano = 100000000;
    public float[] Distancia;
    private void Start()
    {
        Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        Distancia =new float [Enemigos.Length];

    }
    private void Update()
    {
        for (int i = 0; i< Enemigos.Length; i++)
        {
            Distancia[i] = Vector3.Distance(Enemigos[i].transform.position, transform.position);
            if (Distancia[i] < MasCercano)
            {
                MasCercano = Distancia[i];
            }
        }
    }
}
