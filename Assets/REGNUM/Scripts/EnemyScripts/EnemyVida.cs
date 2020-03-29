using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVida : MonoBehaviour
{

    public float vidaEnemy;

    [SerializeField] EnemyHealthBar barritaVida;
    public float vida;

    void Start()
    {

    }
    public void GetDamage(float dañar, float impulse)
    {
        vidaEnemy -= dañar;
        Debug.Log("Tocado");
    }

    // Update is called once per frame
    void Update()
    {


        if (vidaEnemy <= 0)
        {
            barritaVida.SetSize(vida);
            if (vida <= 0)

            {
                Destroy(this.gameObject);
            }
        }



    }
 }

