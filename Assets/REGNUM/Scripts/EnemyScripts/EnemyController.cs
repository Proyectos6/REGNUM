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


    [Header("Ruta")]
    [SerializeField] GameObject goPosicionesRuta;
    [SerializeField] Transform[] puntosRuta; //Array de puntos a los que irá en ruta 
    int puntoActualRuta = 0; //Control del punto actual al que se mueve el Enemigo

    [Header("AI Distance")]
    [SerializeField] float distanciaAlerta = 10;
    [SerializeField] float distanciaVueltaAlSpawn = 20;
    [SerializeField] float distanciaSeparacionPlayer = 2;

    float distanciaConPlayer;
    Vector3 puntoSpawn;



    GameObject goPlayer;
    NavMeshAgent cmpAgent; //Componente del Enemy (IA)
    private NavMeshPath caminoHaciaDestino;

    EnemyAttack ataqueEnemy;

    /*
    bool cercaParaAtacar = false;

    bool ejecutandoAtaque = false;
    float golpeFinalizado = 1.1f;
    [SerializeField] float tiempoNextAttack = 3;

    private Animator cmpAnimator;

    [Header("goWeapon")]
    //Variables Para Coger cmpCollider del weapon y activarlo o desactivarlo segun la animacion de ataque definida

    [SerializeField] CapsuleCollider cmpWeaponCollider;
    bool collWeaponEnable = false;

    */


    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();

        goPlayer = GameObject.FindGameObjectWithTag("Player");

        ataqueEnemy = GetComponent<EnemyAttack>();

        //cmpAnimator = GetComponent<Animator>();
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
            SetearDireccionPatrulla();
        }




        // collWeaponEnable = false;
        //cmpAnimator.SetFloat("SpeedEnemy", Mathf.Abs(cmpAgent.velocity.z) + Mathf.Abs(cmpAgent.velocity.x));
        //cmpWeaponCollider.enabled = collWeaponEnable;

    }


    // Update is called once per frame
    void Update()
    {
        if (cmpAgent.enabled)
        {
            if (!ataqueEnemy.isAttacking)
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
            }

        }



        /*
        if (cercaParaAtacar)
        {
            this.transform.LookAt(goPlayer.transform);
        }

        cmpAnimator.SetFloat("SpeedEnemy", Mathf.Abs(cmpAgent.velocity.z) + Mathf.Abs(cmpAgent.velocity.x));
        cmpAnimator.SetBool("AttackEnemy", cercaParaAtacar);      
        */
    }


    void SetearDireccionPatrulla()
    {
        estadoActual = EstadoEnemigo.Patrulla;

        Transform destinoActual = puntosRuta[puntoActualRuta];
        cmpAgent.SetDestination(destinoActual.position);

        //cmpAgent.stoppingDistance = 0; //Para que el enemigo llegue hasta el punto
    }


    void ComprobarLlegadaDestino()
    {
        if (cmpAgent.pathPending == false)
        {
            if (cmpAgent.remainingDistance < 0.5f)
            {
                float timeWaiting = Time.time + 2;

                if (puntoActualRuta == puntosRuta.Length - 1)
                {
                    puntoActualRuta = 0;
                }
                else
                {
                    ++puntoActualRuta;
                }
                this.transform.LookAt(puntosRuta[puntoActualRuta]);

                if (timeWaiting >= Time.time) //Delay antes de setear nueva direccion, NO SE MOVERA HASTA FIN DELAY
                {
                    SetearDireccionPatrulla();
                }
            }
        }

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

    }

    void VolverSpawn()
    {
        puntoActualRuta = 0;
        estadoActual = EstadoEnemigo.VolverSpawn;
        cmpAgent.stoppingDistance = 0;
        cmpAgent.SetDestination(puntosRuta[puntoActualRuta].transform.position);

    }


    /*
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
    }
    */



}
