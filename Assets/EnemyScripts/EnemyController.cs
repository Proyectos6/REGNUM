using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{

    NavMeshAgent cmpAgent; //Componente del Enemy (IA)

    [SerializeField] Transform[] puntosRuta; //Array de puntos a los que irá en ruta 
    int puntoActualRuta = 0; //Control del punto actual al que se mueve el Enemigo

    [SerializeField] GameObject goPosicionesRuta;


    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
        goPosicionesRuta.transform.parent = null;
    }

    private void Start()
    {
        puntoActualRuta = 0;
        SetDestination();

    }


    // Update is called once per frame
    void Update()
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
                SetDestination();
            }
        }

    }


    void SetDestination()
    {
        Transform destinoActual = puntosRuta[puntoActualRuta];
        cmpAgent.SetDestination(destinoActual.position);
    }
}
