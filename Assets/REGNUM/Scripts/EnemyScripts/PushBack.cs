using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PushBack : MonoBehaviour
{

    Rigidbody cmpRbody;
    NavMeshAgent cmpAgent;
    Animator cmpAnimator;
    bool tocado = false;

    // float totalMove; //DEBUG VARIABLE
    bool isDie;

    private void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
        cmpRbody = GetComponent<Rigidbody>();
        cmpAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            if (!isDie)
            {
                ActivePush();          
            }       
        }
    }

    void ActivePush()
    {
        tocado = true;
        cmpAgent.isStopped = true;
        cmpAgent.updatePosition = false;

        cmpAnimator.SetTrigger("PushedBack");
        //totalMove = 0;
    }



    void DisablePush()
    {
        tocado = false;
        cmpAgent.isStopped = false;
        cmpAgent.updatePosition = true;
        cmpAgent.Warp(transform.position); //Warp Teletransporta        
        cmpAnimator.ResetTrigger("PushedBack");
        GetComponent<EnemyAttack>().AnimEventFinishAttack(); //BUG CONTROL, desactivar el ataque. A veces se queda pillada la variable isAttacking;
        //print(totalMove); DEBUG TESTING
    }

    void AnimEventFinKnock()
    {
        DisablePush();
    }

    private void OnAnimatorMove()
    {
        if (tocado)
        {
            Vector3 rootPos = cmpAnimator.rootPosition; //donde quiere animacion q este personaje
            Vector3 difPos = rootPos - this.transform.position;
            transform.Translate(difPos, Space.World);

            //totalMove += difPos.magnitude; DEBUG TESTING 
        }
    }

    void EnemyDie()
    {
        isDie = true;
    }

}
