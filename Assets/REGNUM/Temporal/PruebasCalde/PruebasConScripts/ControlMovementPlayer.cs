using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovementPlayer : MonoBehaviour
{
    MoveCharControl cmpMovMando;
    Movimiento cmpMovOriginal;
    Animator cmpAnimator;

    [SerializeField] bool movimientoTeclado = true;

    [SerializeField] RuntimeAnimatorController animatorMando,animatorTeclado;

    private void Awake()
    {
        cmpMovMando = GetComponent<MoveCharControl>();
        cmpMovOriginal = GetComponent<Movimiento>();
        cmpAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (movimientoTeclado)
        {
            cmpMovMando.enabled = false;
            cmpMovOriginal.enabled = true;
            cmpAnimator.runtimeAnimatorController = animatorTeclado;
        }
        else if(!movimientoTeclado)
        {
            cmpMovOriginal.enabled = false;
            cmpMovMando.enabled = true;
            cmpAnimator.runtimeAnimatorController = animatorMando;
        }
    }
}
