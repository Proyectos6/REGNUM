using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    bool OnRange;
    GameObject Enemy;
    EnemyVida Vida;
    //Collider ZonaGolpe;
    float Daño;
    float TimerGolpe; 
    public Animator AnimacionesJugador;
    [SerializeField]
    public bool Atacando;

    public KeyCode AtaquePesado;
    public KeyCode AtaqueLigero;
    public float DañoAtaquePesado;
    public float DañoAtaqueLigero;
    public float TimerAtaqueLigero;
    public float TimerAtaquePesado;
    bool Ataque1;
    bool Ataque2;
    

    public GameObject[] Triggers;
    
    void ActiveTrigger(int trigger)
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i].SetActive(false);

        }
        Triggers[trigger].SetActive(true);
    }
    void ActivarTriggerLigero(int trigger)
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i].SetActive(false);
        }
        Triggers[trigger].SetActive(true);
    }
    void FinAtaque()
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i].SetActive(false);
        }
    }

    void Start()
    {
                
    }
    void Update()
    {
        if (Ataque1 == false)
        {
            if (Ataque2 == false)
            {
                if (Input.GetKeyDown(AtaquePesado))
                {
                    AnimacionesJugador.SetBool("AtaquePesado", true);
                    Daño = DañoAtaquePesado;
                    TimerGolpe = TimerAtaquePesado;
                    Ataque2 = true;
                    Atacando = true;

                }
                if (Input.GetKeyDown(AtaqueLigero))
                {
                    AnimacionesJugador.SetBool("AtaqueLigero", true);
                    Daño = DañoAtaqueLigero;
                    TimerGolpe = TimerAtaqueLigero;
                    Ataque1 = true;
                    Atacando = true;
                }
            }
        }
    }
    void FixedUpdate()
    {
            TimerGolpe -= Time.fixedDeltaTime;

        if (TimerGolpe <= 0)
            {

                Atacando = false;
                Ataque1 = false;
                Ataque2 = false;
                AnimacionesJugador.SetBool("AtaquePesado", false);
                AnimacionesJugador.SetBool("AtaqueLigero", false);
            for (int i = 0; i < Triggers.Length; i++)
            {
                Triggers[i].SetActive(false);

            }
        }
    }
}
