using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBackPlayer : MonoBehaviour
{
    Animator cmpAnimator;
    CharacterController cmpCC;

    bool isPushBack = false;
    public bool IsPushBack => isPushBack;

    private void Awake()
    {
        cmpAnimator = GetComponent<Animator>();
        cmpCC = GetComponent<CharacterController>();
    }

    void AnimEventFinKnock()
    {
        isPushBack = false;
        SendMessage("InmortalOff");

        ResetTriggerAnim();   
        cmpAnimator.ResetTrigger("PushBackPlayer");
    }

    void ActivePushPlayer()
    {
        isPushBack = true;

        ResetTriggerAnim();
        cmpAnimator.SetTrigger("PushBackPlayer");

        //totalMove = 0;
    }
    private void OnAnimatorMove()
    {
        if (isPushBack)
        {          
            Vector3 rootPos = cmpAnimator.rootPosition; //donde quiere animacion q este personaje
            Vector3 difPos = rootPos - this.transform.position;

            cmpCC.Move(difPos);           
            //totalMove += difPos.magnitude; DEBUG TESTING 
        }
    }

    void ResetTriggerAnim()
    {
        //Reseteo valores del Animator evitar Bugs
        cmpAnimator.ResetTrigger("EsquivarPlayer");
        cmpAnimator.ResetTrigger("AttackLigeroPlayer");
        cmpAnimator.ResetTrigger("AttackLigeroPlayer");
    }
}
