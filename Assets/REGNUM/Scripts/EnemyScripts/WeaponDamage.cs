﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] float damageWeapon = 10;
    public GameObject dangre;
   

    //DEAL DAMAGE TO PLAYER
    private void OnTriggerEnter(Collider other)
    {
        //print("colisiono " + other.name);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<VidaPlayer>().TakeDamage(damageWeapon);
            dangre.SetActive(true);
            
        }
    }
    private void Update()
    {
        dangre.SetActive(false);
    }

}
