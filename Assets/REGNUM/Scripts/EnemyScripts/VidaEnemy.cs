﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VidaEnemy : VidaBase
{

    [SerializeField] GameObject prefabSangreEnemy;
    [SerializeField] Transform spawnSangre;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        ParticulasSangreEnemy();
    }

    private void ParticulasSangreEnemy()
    {
        GameObject particulaSangre = Instantiate(prefabSangreEnemy, spawnSangre.position, Quaternion.identity);
        Destroy(particulaSangre, 2);
        particulaSangre.transform.parent = null;
    }

    protected override void Morir()
    {
        base.Morir(); //Esta linea mantiene el metodo virtual escrito en Vida, despues reproduce su propio comportamiento.
        
        SendMessage("EnemyDie");
        Destroy(this.gameObject, 5);
    }


}
