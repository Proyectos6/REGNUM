using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dañar : MonoBehaviour
{
    //GameObject Enemigo;
    //EnemyVida VIDA;
    public GameObject Hacha1H;
    public GameObject Hacha2H;
    public Animator Anim;
    public ParticleSystem sangreParticles;

    float Daño;
    //float Impulse;
    

    public float DañoAxe1HL;
    public float DañoAxe1HP;
    public float DañoAxe2HL;
    public float DañoAxe2HP;
    //public float ImpulseAxe1H;
    //public float ImpulseAxe2H;
    void Awake()
    {
    }
    void Update()
    {
        if (Hacha1H.active)
        {
            if (Anim.GetBool("AtaquePesado"))
            {
                Daño = DañoAxe1HP;
                //Debug.Log("AtaquePesado");
            }
            if (Anim.GetBool("AtaqueLigero"))
            {
                Daño = DañoAxe1HL;
                //Debug.Log("AtaqueLigero");
            }

            //Impulse = ImpulseAxe1H;
        }
        if (Hacha2H.active)
        {
            if (Anim.GetBool("AtaquePesado"))
            {
                Daño = DañoAxe2HP;
                //Debug.Log("AtaquePesado");
            }
            if (Anim.GetBool("AtaqueLigero"))
            {
                Daño = DañoAxe2HL;
                //Debug.Log("AtaqueLigero");
            }
            //Impulse = ImpulseAxe2H;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemigo")
        {
            sangreParticles.Play();
            col.GetComponent<VidaEnemy>().TakeDamage(Daño);
        }
    }
}
