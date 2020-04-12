using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVida : MonoBehaviour
{
    [Header("Stats")]
    public float vidaInicial;
    float vidaEnemy;

    //public float vida;
    [Header("Interfaz")]
    [SerializeField] EnemyHealthBar barritaVida;

   


    void Start()
    {
        vidaEnemy = vidaInicial;

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

        barritaVida.SetSize((vidaEnemy / vidaInicial) * 12.6f);
        if (vidaEnemy <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void TakeDamage(float damageRecibido)
    {
        vidaEnemy -= damageRecibido;

        /*Vector3 pushdirection = golpePos - this.transform.position;
        pushdirection = -pushdirection.normalized;
        print(pushdirection);*/
       // GetComponent<Rigidbody>().AddForce(Vector3.forward * -forceKnockback * 100, ForceMode.Impulse);
        //Destroy(this.gameObject);

    }
    
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * -forceKnockback, ForceMode.Impulse);
        }
    }


    */

}


