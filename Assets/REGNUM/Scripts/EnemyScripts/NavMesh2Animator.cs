using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMesh2Animator : MonoBehaviour
{
    Animator cmpAnimator;
    NavMeshAgent cmpAgent;

    [SerializeField] float interpolationSpeed = 3;
    float animatorSpeed;

    private void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
        cmpAnimator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float agentSpeed = cmpAgent.velocity.magnitude; //Adquiero la velocidad del agente y como me interesa un float cojo su magnitud.
        animatorSpeed = Mathf.MoveTowards(animatorSpeed, agentSpeed, interpolationSpeed * Time.deltaTime);
        cmpAnimator.SetFloat("SpeedEnemy", agentSpeed);
    }
}
