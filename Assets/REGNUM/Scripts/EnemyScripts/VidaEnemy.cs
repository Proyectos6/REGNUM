﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VidaEnemy : VidaBase
{
    protected override void Morir()
    {
        //base.Morir(); //Esta linea mantiene el metodo virtual escrito en Vida, despues reproduce su propio comportamiento.
        
        SendMessage("EnemyDie");
        cmpAnimator.SetTrigger("isDie");
        Destroy(this.gameObject, 5);

    }


}
