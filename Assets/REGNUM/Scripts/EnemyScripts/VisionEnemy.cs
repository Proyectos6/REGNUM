using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEnemy : MonoBehaviour
{
    [SerializeField] float radioDeteccion = 5;
    float distanceActual;
    GameObject goPlayer, pechoLookTarget;

    Vector3 raycastOrigen, raycastTarget;

    [SerializeField] float angleVisionEnemy=45;

    private void Awake()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player"); //Referencia al GameObject del Player
        pechoLookTarget = GameObject.FindGameObjectWithTag("PlayerTargetPecho"); //Referencia al GameObject pechoPlayer, almacenado en cmpControlJugador...
    }

    void Start()
    {
        if (pechoLookTarget == null)
        {
            pechoLookTarget = GameObject.FindGameObjectWithTag("PlayerTargetPecho");
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceActual = Vector3.Distance(this.transform.position, goPlayer.transform.position);      
    }

    public bool ComprobarVisionAlJugador()
    {
        if (distanceActual < radioDeteccion) //PrimeraCondicion
        {
            //print("True 1Condicion"); DEBUG
            //CREAR CONO DE VISION CON LAS DOS LINEAS SIGUIENTES
            Vector3 targetDir = goPlayer.transform.position - this.transform.position; //Marco un Vector entre Posicion Enemigo y Player
            float visionAngle = Vector3.Angle(transform.forward, targetDir); //Calculo el Angulo entre el Forward del Enemigo y el Vector direccion entre Player-Enemigo.

            if (visionAngle <= angleVisionEnemy) //SegundaCondicion
            {
                //print("True 2Condicion");DEBUG

                raycastOrigen = this.transform.position;
                raycastTarget = pechoLookTarget.transform.position - this.transform.position;
                RaycastHit infoImpacto;

                if (Physics.Raycast(raycastOrigen, raycastTarget, out infoImpacto, radioDeteccion))
                {
                    if (infoImpacto.collider.gameObject == goPlayer) //TerceraCondicion
                    {
                        //print("True 3Condicion"); DEBUG
                        return true; //Cumplidas las tres condiciones devuelve true al método.
                    }
                    else { return false; }//Fail TerceraCondicion
                }
            }
            else { return false; } //Fail SegundaCondicion
        }

        //print("False 1Condicion"); DEBUG
        return false; //Fail PrimeraCondicion
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(raycastOrigen, raycastTarget * radioDeteccion);
    }
}
