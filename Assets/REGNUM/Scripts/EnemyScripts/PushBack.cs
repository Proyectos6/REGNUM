using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PushBack : MonoBehaviour
{
    Rigidbody cmpRbody;
    NavMeshAgent cmpAgent;
    Animator cmpAnimator;

    [SerializeField] Transform playerTransform;

    [SerializeField] float speedForce = 10;
    [SerializeField] float speedRalenti = 9.8f;

    Vector3 dirDesplazado;
    bool tocado = false;

    [SerializeField] Transform dirInspector;

    private void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
        cmpRbody = GetComponent<Rigidbody>();
        cmpAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!cmpAgent.enabled)
        {


            if (cmpRbody.velocity.magnitude < 0)
            {
                //cmpRbody.velocity += Vector3.forward * speedRalenti * Time.deltaTime;
                cmpRbody.velocity = Vector3.MoveTowards(cmpRbody.velocity, Vector3.zero, speedRalenti);
            }
            if (cmpRbody.velocity.magnitude >= 0)
            {
                cmpRbody.velocity = Vector3.zero;
                DisablePush();
            }
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            cmpAnimator.SetTrigger("PushedBack");

            /*Vector3 dirBackward = other.transform.position - this.transform.position;
            dirDesplazado = dirBackward;*/

            Vector3 dirBackwards = this.transform.position - dirInspector.position;
            dirDesplazado = dirBackwards;
            //activePush();
        }
    }

    void ActivePush()
    {
        tocado = true;
        cmpAgent.enabled = false;
        cmpRbody.isKinematic = false;
        
        Vector3 dirFinal = playerTransform.position - this.transform.position;
        cmpRbody.velocity = transform.TransformDirection(dirDesplazado * -speedForce);

        //cmpRbody.AddForce(dirDesplazado * speedForce, ForceMode.Impulse);

        //cmpAnimator.applyRootMotion = true;
        //cmpRbody.velocity = transform.TransformDirection(dirDesplazado * -speedForce);
        //cmpRbody.AddForce(Vector3.forward * -speedForce, ForceMode.Impulse);
    }
    void DisablePush()
    {
        tocado = false;
        cmpRbody.velocity = Vector3.zero;
        //cmpAnimator.applyRootMotion = false;
        //cmpAnimator.ResetTrigger("PushedBack");
        cmpRbody.isKinematic = true;
        cmpAgent.enabled = true;
    }

   /* private void OnAnimatorIK(int layerIndex)
    {
       /* if (!tocado)
        {
            cmpAnimator.ResetTrigger("PushedBack");
        }

        if (tocado)
        {
            //cmpAnimator.SetTrigger("PushedBack");
            //cmpAnimator.applyRootMotion = true;
        }
        else
        {
            cmpAnimator.ResetTrigger("PushedBack");
            //cmpAnimator.applyRootMotion = false;
        }
    }*/

    private void OnAnimatorMove()
    {
        if (!tocado)
        {
            cmpAnimator.ResetTrigger("PushedBack");
        }
    }

    void AnimEventKnockback()
    {
        ActivePush();
    }
    void AnimEventFinKnock()
    {
        DisablePush();
    }
}
