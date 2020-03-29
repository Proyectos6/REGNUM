using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVida : MonoBehaviour
{

    public float vidaEnemy;

    [SerializeField] EnemyHealthBar barritaVida;
    public float vida;

    float VidaInicial;

    void Start()
    {
        VidaInicial = vidaEnemy;

        barritaVida = GetComponentInChildren<EnemyHealthBar>();
    }
    public void GetDamage(float dañar, float impulse)
    {
        vidaEnemy -= dañar;
        Debug.Log("Tocado");
    }

    // Update is called once per frame
    void Update()
    {

        barritaVida.SetSize((vidaEnemy/VidaInicial) * 12.61f);

        if (vidaEnemy <= 0)
        {
            barritaVida.SetSize(vida);
            if (vida <= 0)

            {
                Destroy(this.gameObject);
            }
        }

        
         void TakeDamage(float damageRecibido)
        {
            vidaEnemy -= damageRecibido;

            Destroy(this.gameObject);

        }

   

    }
 }

