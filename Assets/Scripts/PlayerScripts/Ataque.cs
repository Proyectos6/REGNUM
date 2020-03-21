using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    bool OnRange;
    GameObject Enemy;
    EnemyVida Vida;
    Collider ZonaGolpe;
    float Daño;
    float TimerGolpe;
    public Animator AnimacionesJugador;

    public KeyCode AtaquePesado;
    public KeyCode AtaqueLigero;
    public float DañoAtaquePesado;
    public float DañoAtaqueLigero;
    public float TimerAtaqueLigero;
    public float TimerAtaquePesado;

    void Start()
    {
        ZonaGolpe = gameObject.GetComponent<BoxCollider>();
        ZonaGolpe.enabled = false;
                
    }
    void Update()
    {
        if (ZonaGolpe.enabled == false)
        {
            if (Input.GetKeyDown(AtaquePesado))
            {
                AnimacionesJugador.SetBool("AtaquePesado", true);
                ZonaGolpe.enabled = true;
                Daño = DañoAtaquePesado;
                TimerGolpe = TimerAtaquePesado;
            }
            if (Input.GetKeyDown(AtaqueLigero))
            {
                AnimacionesJugador.SetBool("AtaqueLigero", true);
                ZonaGolpe.enabled = true;
                Daño = DañoAtaqueLigero;
                TimerGolpe = TimerAtaqueLigero;
            }
        }
    }
    void FixedUpdate()
    {
        if (ZonaGolpe.enabled == true)
        {
            TimerGolpe -= Time.fixedDeltaTime;
            if (TimerGolpe <= 0)
            {
                AnimacionesJugador.SetBool("AtaquePesado", false);
                AnimacionesJugador.SetBool("AtaqueLigero", false);
                ZonaGolpe.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemigo")
        {
                Enemy = col.gameObject;
                Vida = Enemy.GetComponent<EnemyVida>();
                Vida.vida -= Daño;
        }
    }
}
