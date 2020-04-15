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

    [SerializeField] Transform playerTransform;

    float totalMove;

    /* 
    [SerializeField] float speedForce = 10;
    [SerializeField] float speedRalenti = 9.8f;

    Vector3 dirDesplazado;

    [SerializeField] Transform dirInspector;
    */

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
            ActivePush();
        }
    }

    void ActivePush()
    {
        print("EMPIEZA GOLPE");
        totalMove = 0;
        tocado = true;
        cmpAgent.isStopped=true;
        cmpAgent.updatePosition = false;
        /*cmpAgent.enabled = false;
        cmpRbody.isKinematic = false;*/
        cmpAnimator.SetTrigger("PushedBack");
    }

   

    void DisablePush()
    {
        tocado = false;
        cmpAgent.isStopped = false;
        cmpAgent.updatePosition = true;
        cmpAgent.Warp(transform.position); //Warp Teletransporta
        /*
        cmpRbody.velocity = Vector3.zero;       
        cmpRbody.isKinematic = true;
        cmpAgent.enabled = true;*/
        print(totalMove);
        cmpAnimator.ResetTrigger("PushedBack");
    }

    private void Update()
    {
        /*
        if (tocado) {  }
        if (!tocado) {  }*/
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
            //cmpAgent.Move(difPos);
            totalMove += difPos.magnitude;

            transform.Translate(difPos, Space.World);
            //print(difPos.magnitude);
        }
    }

}
