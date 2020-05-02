using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    KeyCode ataquePesadoJoystick=KeyCode.Joystick1Button4; //Input Mapping for Joystick;
    public KeyCode AtaqueLigero;
    KeyCode ataqueLigeroJoystick=KeyCode.Joystick1Button5; //Input Mapping for Joystick;
    public float DañoAtaquePesado;
    public float DañoAtaqueLigero;
    [HideInInspector] public float TimerAtaqueLigero = 1.46f;
    [HideInInspector] public float TimerAtaquePesado = 2.56f;
    bool Ataque1;
    bool Ataque2;
     public TrailRenderer trail;
    public GameObject particlesDeDaño;
    public GameObject[] Triggers;
    public GameObject[] TriggersAltoRango;
    public GameObject particulasHacha;
    

     
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
        particulasHacha.SetActive(false);
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
    /*
    void Update()
    {
        
        if (Ataque1 == false)
        {
       
            //particlesDeDaño.SetActive(false);
            if (Ataque2 == false)
            {
                //particlesDeDaño.SetActive(false);
                if (Input.GetKeyDown(AtaquePesado) || Input.GetKeyDown(ataquePesadoJoystick)) //condicion OR, Raton o Joystick activan el ataque
                {
                    AnimacionesJugador.SetBool("AtaquePesado", true);
                    Daño = DañoAtaquePesado;
                    TimerGolpe = TimerAtaquePesado;
                    Ataque2 = true;
                    Atacando = true;
                    particulasHacha.SetActive(true);

                }
                if (Input.GetKeyDown(AtaqueLigero) || Input.GetKeyDown(ataqueLigeroJoystick)) //condicion OR, Raton o Joystick activan el ataque
                {
                    AnimacionesJugador.SetBool("AtaqueLigero", true);
                    Daño = DañoAtaqueLigero;
                    TimerGolpe = TimerAtaqueLigero;
                    Ataque1 = true;
                    Atacando = true;
                    particulasHacha.SetActive(true);

                    
                   // particlesDeDaño.SetActive(true);
                }
            }
        }
    }
    */
}
