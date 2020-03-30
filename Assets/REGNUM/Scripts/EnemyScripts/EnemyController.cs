using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    enum EstadoEnemigo
    {
        Patrulla,
        PersiguiendoPlayer,
        VolverSpawn,
        AtacarAlPlayer
    }

    EstadoEnemigo estadoActual;


    [SerializeField] Transform[] puntosRuta; //Array de puntos a los que irá en ruta 
    int puntoActualRuta = 0; //Control del punto actual al que se mueve el Enemigo

    [SerializeField] GameObject goPosicionesRuta;

    Vector3 puntoSpawn;
    [SerializeField] float distanciaAlerta = 10;
    [SerializeField] float distanciaVueltaAlSpawn = 20;
    [SerializeField] float distanciaSeparacionPlayer = 2;
    float distanciaConPlayer;
    bool cercaParaAtacar = false;

    //bool ejecutandoAtaque = false;
    //float golpeFinalizado = 1.1f;
    //[SerializeField] float tiempoNextAttack = 3;


    GameObject goPlayer;

    NavMeshAgent cmpAgent; //Componente del Enemy (IA)
    private NavMeshPath caminoHaciaDestino;


    private Animator cmpAnimator;
    private float speed4Animator;


    //Variables Para Coger cmpCollider del weapon y activarlo o desactivarlo segun la animacion de ataque definida

    [SerializeField] CapsuleCollider cmpWeaponCollider;
    bool collWeaponEnable = false;





    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();

        goPlayer = GameObject.FindGameObjectWithTag("Player");

        cmpAnimator = GetComponent<Animator>();

        //cmpWeaponCollider = GameObject.FindGameObjectWithTag("EnemyWeapon").GetComponent<CapsuleCollider>();

    }

    private void Start()
    {
        
        if (goPosicionesRuta != null)
        {
            goPosicionesRuta.transform.parent = null;
        }

        estadoActual = EstadoEnemigo.Patrulla; //Empieza en Patrulla

        puntoSpawn = this.transform.position; //guardo PosInicial

        puntoActualRuta = 0;

        if (puntosRuta != null)
        {
            SetearDireccion();
        }



        cmpAnimator.SetFloat("SpeedEnemy", Mathf.Abs(cmpAgent.velocity.z) + Mathf.Abs(cmpAgent.velocity.x));

        collWeaponEnable = false;
        //cmpWeaponCollider.enabled = collWeaponEnable;

    }


    // Update is called once per frame
    void Update()
    {
        if (estadoActual == EstadoEnemigo.Patrulla) //Estado Patrulla, Enemy ejecuta este comportamiento
        {
            ComprobarLlegadaDestino();

            ComprobarAlertaPlayer();
        }

        else if (estadoActual == EstadoEnemigo.PersiguiendoPlayer) //Estado Perseguir Player
        {
            PerseguirPlayer();

            ComprobarAlejarseElPlayer();
            ComprobarDistanciaVolver();

        }


        else if (estadoActual == EstadoEnemigo.VolverSpawn) //Estado Volver al Spawn
        {

            ComprobarLlegadaDestino();
        }

        else if (estadoActual == EstadoEnemigo.AtacarAlPlayer)
        {
            CheckPosibleAtaque();
        }

        if (cercaParaAtacar)
        {
            this.transform.LookAt(goPlayer.transform);
        }

       

        cmpAnimator.SetFloat("SpeedEnemy", Mathf.Abs(cmpAgent.velocity.z) + Mathf.Abs(cmpAgent.velocity.x));
        cmpAnimator.SetBool("AttackEnemy", cercaParaAtacar);      
    }


    void ComprobarLlegadaDestino()
    {
        if (cmpAgent.pathPending == false)
        {
            if (cmpAgent.remainingDistance < 0.5f)
            {
                if (puntoActualRuta == puntosRuta.Length - 1)
                {
                    puntoActualRuta = 0;
                }
                else
                {
                    ++puntoActualRuta;
                }
                SetearDireccion();
            }
        }

    }

    void SetearDireccion()
    {
        estadoActual = EstadoEnemigo.Patrulla;

        Transform destinoActual = puntosRuta[puntoActualRuta];

        cmpAgent.stoppingDistance = 0; //Para que el enemigo llegue hasta el punto
        cmpAgent.SetDestination(destinoActual.position);
    }



    void ComprobarAlertaPlayer()
    {
        distanciaConPlayer = Vector3.Distance(this.transform.position, goPlayer.transform.position);

        if (distanciaConPlayer < distanciaAlerta)
        {
            PerseguirPlayer();
        }


    }


    void PerseguirPlayer()
    {
        estadoActual = EstadoEnemigo.PersiguiendoPlayer;
        cmpAgent.stoppingDistance = distanciaSeparacionPlayer; //Para que Enemigo se situe a una distancia del Player (después ejecuta ataque)
        cmpAgent.SetDestination(goPlayer.transform.position);
    }

    void ComprobarDistanciaVolver()
    {
        float distanciaConSpawn = Vector3.Distance(this.transform.position, puntoSpawn);

        if (distanciaConSpawn > distanciaVueltaAlSpawn)
        {
            VolverSpawn();
        }
    }


    void ComprobarAlejarseElPlayer()
    {
        float distanciaConPlayer = Vector3.Distance(this.transform.position, goPlayer.transform.position);

        if (distanciaConPlayer > distanciaAlerta)
        {
            estadoActual = EstadoEnemigo.VolverSpawn;
            puntoActualRuta = 0;
            VolverSpawn();
        }

        if (distanciaConPlayer <= distanciaSeparacionPlayer + 0.5f)
        {
            cercaParaAtacar = true;
        }
        else if (distanciaConPlayer > distanciaSeparacionPlayer + 0.5f)
        {
            cercaParaAtacar = false;
        }
    }

    void VolverSpawn()
    {
        puntoActualRuta = 0;

        estadoActual = EstadoEnemigo.VolverSpawn;
        cmpAgent.stoppingDistance = 0;
        cmpAgent.SetDestination(puntoSpawn);
    }

    //Change Collider Active Component During The Attack
    void SwitchColliderEnabled(int isEnabled)
    {
        if (isEnabled == 0)
        {
            collWeaponEnable = false;
            cmpWeaponCollider.enabled = collWeaponEnable;//Active/Disabled Weapon Collider
        }
        if (isEnabled == 1)
        {
            collWeaponEnable = true;
            cmpWeaponCollider.enabled = collWeaponEnable;//Active/Disabled Weapon Collider
        }

        /*
        collWeaponEnable = !collWeaponEnable;
        cmpWeaponCollider.enabled = collWeaponEnable;
        */
    }


    void CheckPosibleAtaque()
    {

        /*
        if (cmpAgent.pathPending == false)
        {
            if (cmpAgent.velocity == Vector3.zero)
            {

                cercaParaAtacar = true;

            }

            else if (cmpAgent.velocity != Vector3.zero || cmpAgent.remainingDistance > distanciaSeparacionPlayer)
            {
                cercaParaAtacar = false;
                estadoActual = EstadoEnemigo.Patrulla;
            }
        }
        */

        /*
                if (Physics.Raycast(this.transform.position, goPlayer.transform.position, distanciaSeparacionPlayer))
                {

                    cercaParaAtacar = true;

                }

                else
                {
                    cercaParaAtacar = false;
                    //estadoActual = EstadoEnemigo.Patrulla;
                }



                /*
                        if (cmpAgent.pathPending == false)
                        {
                            if (cmpAgent.remainingDistance > distanciaSeparacionPlayer)
                            {
                                cercaParaAtacar = false;
                            }
                            else
                            {
                                cercaParaAtacar = true;
                            }
                        }

                        */

    }


    /* void tiempoEntreAtaques()
     {
         if (cercaParaAtacar)
         {






         }


     }*/


}
