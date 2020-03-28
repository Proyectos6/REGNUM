using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVida : MonoBehaviour
{
    public float vidaEnemy;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (vidaEnemy <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void TakeDamage(float damageRecibido)
    {
        vidaEnemy -= damageRecibido;

    }



}
