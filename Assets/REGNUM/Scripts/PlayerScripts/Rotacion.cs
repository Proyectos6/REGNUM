﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    Vector3 mousePos;
    public Transform PTL;
    Rigidbody rid;
    Ataque Ataque;
    public GameObject[] Enemigos;

    public float velocidadRotacion = 360;
    void Awake()
    {
        rid = this.GetComponent<Rigidbody>();
        Ataque = this.GetComponent<Ataque>();
        Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
    }
    void FixedUpdate() 
    {
        if (Ataque.Atacando == false)
        {
            Vector3 pointToLook = PTL.position;
            pointToLook.y = transform.position.y;
            Quaternion mirar = Quaternion.LookRotation(pointToLook - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, mirar, velocidadRotacion * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider col)
    {

    }


}



