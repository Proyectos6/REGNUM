using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float vidaMax = 100;
    protected float vidaActual;

    public float VidaMax => vidaMax;


    public float VidaActual
    {
        get { return vidaActual; }
    }


    protected Animator cmpAnimator;

    protected bool isInmortal = false;

    protected void Awake()
    {
        cmpAnimator = GetComponent<Animator>();
        vidaActual = vidaMax;
    }


    public virtual void TakeDamage(float damage)
    {
        if (!isInmortal)
        {
            vidaActual -= damage;     
            if (vidaActual <= 0)
            {
                Morir();
            }
        }
    }

    protected virtual void Morir()
    {
        //Configurado activar animacion de Morir tanto en Player como en enemigo
        cmpAnimator.SetTrigger("isDie");  
    }
}
