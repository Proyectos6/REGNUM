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
        VolverSpawn
    }

    EstadoEnemigo estadoActual;


    [SerializeField] Transform[] puntosRuta; //Array de puntos a los que irá en ruta 
    int puntoActualRuta = 0; //Control del punto actual al que se mueve el Enemigo

    [SerializeField] GameObject goPosicionesRuta;

    Vector3 puntoSpawn;
    [SerializeField] float distanciaAlerta = 10;
    [SerializeField] float distanciaVueltaAlSpawn = 20;
    [SerializeField] float distanciaSeparacionPlayer = 5;
    float distanciaConPlayer;


    GameObject goPlayer;

    NavMeshAgent cmpAgent; //Componente del Enemy (IA)
    private NavMeshPath caminoHaciaDestino;


    private Animator cmpAnimator;
    private float speed4Animator;

    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();

        goPlayer = GameObject.FindGameObjectWithTag("Player");

        cmpAnimator = GetComponent<Animator>();


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
    }


    // Update is called once per frame
    void Update()
    {
        print(cmpAgent.velocity);

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

        cmpAnimator.SetFloat("SpeedEnemy", Mathf.Abs(cmpAgent.velocity.z) + Mathf.Abs(cmpAgent.velocity.x));
    }


    void ComprobarLlegadaDestino()
    {
        if (cmpAgent.pathPending == false)
        {
            if (cmpAgent.remainingDistance < 0.5f)
            {
                if (puntoActualRuta == puntosRuta.Length)
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
    }

    void VolverSpawn()
    {
        puntoActualRuta = 0;

        estadoActual = EstadoEnemigo.VolverSpawn;
        cmpAgent.stoppingDistance = 0;
        cmpAgent.SetDestination(puntoSpawn);
    }






}
