using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerV2 : MonoBehaviour
{
    [Header("Ruta")]
    [SerializeField] GameObject goPosicionesRuta;
    [SerializeField] Transform[] puntosRuta; //Array de puntos a los que irá en ruta

    [Header("AI Distance")]
    [SerializeField] float distanciaAlerta = 10;
    [SerializeField] float distanciaVueltaAlSpawn = 20;
    [SerializeField] float distanciaSeparacionPlayer = 2;

    float distanciaConPlayer;
    Vector3 puntoSpawn;

    //COMPONENTES
    GameObject Player;
    NavMeshAgent cmpAgent; //Componente del Enemy (IA)
    private NavMeshPath caminoHaciaDestino;
    EnemyAttack ataqueEnemy;

    bool isDie = false; //BUG CONTROL 
    bool playerAlert = false;
    VisionEnemy visionEnemy;

    public int puntoRutaActual = 0;

    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();

        Player = GameObject.FindGameObjectWithTag("Player");

        ataqueEnemy = GetComponent<EnemyAttack>();

        //cmpAnimator = GetComponent<Animator>();
        //cmpWeaponCollider = GameObject.FindGameObjectWithTag("EnemyWeapon").GetComponent<CapsuleCollider>();

        visionEnemy = GetComponent<VisionEnemy>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (!isDie)
        {
            if (playerAlert == true)
            {
                FollowPlayer();
            }
            else
            {
                Patrol();
            }
        } 
    }
    void Patrol()
    {
        if(puntoRutaActual < puntosRuta.Length)
        {
            float Dist = Vector3.Distance(puntosRuta[puntoRutaActual].position, transform.position);
            cmpAgent.SetDestination(new Vector3(puntosRuta[puntoRutaActual].position.x, transform.position.y, puntosRuta[puntoRutaActual].position.z));
            if (Dist < 3)
            {
                Debug.Log("llegue");
                puntoRutaActual++;
            }
        }
        else
        {
            puntoRutaActual = 0;
        }
    }
    void FollowPlayer()
    {
        cmpAgent.stoppingDistance = distanciaSeparacionPlayer;
        cmpAgent.SetDestination(Player.transform.position);
        transform.LookAt(Player.transform.position);

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerAlert = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerAlert = false;
        }
    }
}
