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
            tocado = true;
        }
    }

    void ActivePush()
    {
        tocado = true;
        cmpAgent.enabled = false;
        cmpRbody.isKinematic = false;    
    }
    void DisablePush()
    {
        tocado = false;
        cmpRbody.velocity = Vector3.zero;       
        cmpRbody.isKinematic = true;
        cmpAgent.enabled = true;
    }

    private void OnAnimatorMove()
    {
        if (tocado) { cmpAnimator.SetTrigger("PushedBack"); }
        if (!tocado) { cmpAnimator.ResetTrigger("PushedBack"); }
    }

    void AnimEventFinKnock()
    {
        DisablePush();
    } 
}
