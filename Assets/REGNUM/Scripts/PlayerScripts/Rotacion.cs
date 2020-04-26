using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    Vector3 mousePos;
    public Transform PTL;
    Rigidbody rid;
    Ataque Ataque;
    Movimiento Mov;

    //Variables fijacion enemigos
    public bool Fijando;
    public GameObject[] Enemigos;
    public int EnemigoFijado;
    public float MaximaDistancia = 5;
    public float MasCercano = 100000000;
    public float[] Distancia;

    public float velocidadRotacion = 360;
    void Awake()
    {
        rid = this.GetComponent<Rigidbody>();
        Ataque = this.GetComponent<Ataque>();
        Mov = this.GetComponent<Movimiento>();

        
    }
    void FixedUpdate() 
    {
        Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        Distancia = new float[Enemigos.Length];
        for (int i = 0; i < Enemigos.Length; i++)
        {
            Distancia[i] = Vector3.Distance(Enemigos[i].transform.position, transform.position);
            if (Distancia[i] < MasCercano)
            {
                MasCercano = Distancia[i];
                EnemigoFijado = i;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (MasCercano <= MaximaDistancia)
            {
                if (Fijando == true)
                {
                    Fijando = false;
                }
                else
                {
                    Fijando = true;
                }
            }

        }

        if (Fijando == false)
        {
            if (Ataque.Atacando == false)
            {
                if (Mov.movDir.x + Mov.movDir.z > 0)
                {
                    Vector3 pointToLook = PTL.position;
                    pointToLook.y = transform.position.y;
                    Quaternion mirar = Quaternion.LookRotation(pointToLook - transform.position);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, mirar, velocidadRotacion * Time.deltaTime);
                }
                if (Mov.movDir.x + Mov.movDir.z < 0)
                {
                    Vector3 pointToLook = PTL.position;
                    pointToLook.y = transform.position.y;
                    Quaternion mirar = Quaternion.LookRotation(pointToLook - transform.position);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, mirar, velocidadRotacion * Time.deltaTime);
                }
            }
        }
        if (Fijando == true)
        {
            if (Ataque.Atacando == false)
            {
                Vector3 pointToLook = Enemigos[EnemigoFijado].transform.position;
                pointToLook.y = transform.position.y;
                Quaternion mirar = Quaternion.LookRotation(pointToLook - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, mirar, velocidadRotacion * Time.deltaTime);
            }
        }
        
    }

}



