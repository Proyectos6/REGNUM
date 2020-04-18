using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    bool OnRange;
    GameObject Enemy;
    //EnemyVida Vida;
    float Daño;
    float TimerGolpe; 
    public Animator AnimacionesJugador;
    [HideInInspector] public bool Atacando;
    //public ParticleSystem particleDaño;
    public KeyCode AtaquePesado;
    public KeyCode AtaqueLigero;
    public float DañoAtaquePesado;
    public float DañoAtaqueLigero;
    [HideInInspector] public float TimerAtaqueLigero = 1.46f;
    [HideInInspector] public float TimerAtaquePesado = 2.56f;
    bool Ataque1;
    bool Ataque2;
    

    public GameObject[] Triggers;
    public GameObject[] TriggersAltoRango;
    
    void ActiveTrigger(int trigger)
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i].SetActive(false);
           // particleDaño.Play();
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
    void Active2HALigero(int trigger)
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i].SetActive(false);
        }
        Triggers[trigger].SetActive(true);
    }
    void Active2HAPesado(int trigger)
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            TriggersAltoRango[i].SetActive(false);
        }
        TriggersAltoRango[trigger].SetActive(true);
    }
    void Active2HAPesadoExpan(int trigger)
    {
        for (int i = 0; i < TriggersAltoRango.Length; i++)
        {
            TriggersAltoRango[i].SetActive(false);
        }
        TriggersAltoRango[0].SetActive(true);
        TriggersAltoRango[1].SetActive(true);
        TriggersAltoRango[2].SetActive(true);
    }
    void FinAtaque()
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
        for (int i = 0; i < TriggersAltoRango.Length; i++)
        {
            TriggersAltoRango[i].SetActive(false);

        }
    }

    void Start()
    {
        for (int i = 0; i < TriggersAltoRango.Length; i++)
        {
            TriggersAltoRango[i].SetActive(false);

        }
        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i].SetActive(false);

        }
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
}
