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
    [SerializeField] float distanciaSeparacionPlayer = 2f;

    float distanciaDetectar = 10;

    //COMPONENTES
    GameObject Player;
    public GameObject Alerta;
    NavMeshAgent cmpAgent; //Componente del Enemy (IA)
    private NavMeshPath caminoHaciaDestino;
    Animator Anim;
    public Collider Arma;

    bool isDie = false; //BUG CONTROL 
    bool playerAlert = false;
    bool Attack = false;
    bool Escape = false;
    VisionEnemy visionEnemy;


    float TimeGoBack = 0.5f;
    float TimeToAttack = 1f;


    public int puntoRutaActual = 0;
    public Transform DemasiadoCerca;

    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();

        Player = GameObject.FindGameObjectWithTag("Player");

        Anim = GetComponent<Animator>();
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
            if (Attack == false)
            {
                if(Escape == false) 
                {
                    float Dist = Vector3.Distance(Player.transform.position, transform.position);
                    if (Dist < distanciaDetectar)
                    {
                        
                        if (Dist > distanciaSeparacionPlayer)
                        {
                            FollowPlayer();
                        }
                        else
                        {
                            Attack = true;
                          //  Debug.Log("ActivoAtaque");
                        }

                     //   Debug.Log("Siguiendo");
                    }
                    else
                    {
                        Patrol();
                       // Debug.Log("Patrullar");
                    }
                }
                else
                {
                    Huir();
                }
                
            }
            else
            {
                Atacando();
            }
            
        } 
    }
    void Patrol()
    {
        if(puntoRutaActual < puntosRuta.Length)
        {
            float DistP = Vector3.Distance(puntosRuta[puntoRutaActual].position, transform.position);
            cmpAgent.SetDestination(new Vector3(puntosRuta[puntoRutaActual].position.x, transform.position.y, puntosRuta[puntoRutaActual].position.z));
            if (DistP < 3)
            {
                //Debug.Log("llegue");
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
        transform.LookAt(Player.transform.position);
        cmpAgent.SetDestination(Player.transform.position);
    }
    void Huir()
    {
        TimeGoBack -= Time.deltaTime;
        if (TimeGoBack <= 0)
        {
            TimeGoBack = 0.5f;
            Escape = false;
            
        }
        transform.LookAt(Player.transform.position);
        cmpAgent.SetDestination(DemasiadoCerca.position);
    }
    void Atacando()
    {
        Alerta.SetActive(true);
        transform.LookAt(Player.transform.position);
        cmpAgent.SetDestination(transform.position);
        TimeToAttack -= Time.deltaTime;
        if (TimeToAttack <= 0)
        {
            Anim.SetBool("Atacar", true);
            Alerta.SetActive(false);
        }
        
    }
    void ColliderArmaActive()
    {
        Arma.enabled = true;
    }
    void ColliderArmaDesActive()
    {
        Arma.enabled = false;
    }
    public void FinishAttack()
    {
        Anim.SetBool("Atacar", false);
        Attack = false;
        Escape = true;
        TimeToAttack = 1f;

        Debug.Log("NOMORE ATTACK");
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
