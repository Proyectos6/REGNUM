using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCCAnimator : ControlCCMovimiento
{
    public bool usarRootMotion = true;

    Animator cmpAnimator;

    bool finSalto = false;


    protected override void Awake()
    {
        base.Awake(); //Realizo Comportamiento del Awake Padre. Despues sobreescribo con el nuevo.
        cmpAnimator = GetComponent<Animator>();
    }
    protected override void AplicarMovimiento() //CHECK
    {
        cmpAnimator.SetFloat("SpeedForward", VelXZLocal.z);
        cmpAnimator.SetFloat("SpeedRigh", VelXZLocal.x);
    }
    private void OnAnimatorMove()
    {
        if (usarRootMotion && !Saltando)
        {
            Vector3 rootMotionPosition = cmpAnimator.rootPosition;
            Vector3 currentPosition = transform.position;
            Vector3 movement = rootMotionPosition - currentPosition;
            cmpCC.Move(movement + Vector3.up * VelocidadY * Time.deltaTime + VelDeslizarGlobal * Time.deltaTime);

            transform.rotation = cmpAnimator.rootRotation;
        }
        else
        {
            base.AplicarMovimiento();
            transform.Rotate(Vector3.up * VelocidadAngular * Time.deltaTime);
        }

    }
}
