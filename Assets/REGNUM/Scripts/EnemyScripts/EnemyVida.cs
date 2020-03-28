using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVida : MonoBehaviour
{
<<<<<<< HEAD
    public float vidaEnemy;


=======
    public EnemyHealthBar barritaVida;
    public float vida;
>>>>>>> 33a209ae5ffd476e50b114fb43c55802230e2213
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

        if (vidaEnemy <= 0)
=======
        barritaVida.SetSize(vida);
        if (vida <= 0)
>>>>>>> 33a209ae5ffd476e50b114fb43c55802230e2213
        {
            Destroy(this.gameObject);
        }
    }


    public void TakeDamage(float damageRecibido)
    {
        vidaEnemy -= damageRecibido;

    }



}
