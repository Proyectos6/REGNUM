﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] GameObject goWeapon;
    Animator cmpAnimator;
    CharacterController cmpCC;
    Movimiento cmpMovimiento;
    PushBackPlayer cmpPushBack;

    bool isAttacking = false;
    public bool IsAttacking => isAttacking;
    bool lowAttack1 = false;
    bool strongAttack = false;
    //Teclas para configurar ataque
    KeyCode AtaquePesado = KeyCode.Mouse1; //Input Mapping for Teclado
    KeyCode ataquePesadoJoystick = KeyCode.Joystick1Button4; //Input Mapping for Joystick;
    KeyCode AtaqueLigero = KeyCode.Mouse0; //Input Mapping for Teclado
    KeyCode ataqueLigeroJoystick = KeyCode.Joystick1Button5; //Input Mapping for Joystick;


    private void Awake()
    {
        cmpAnimator = GetComponent<Animator>();
        cmpCC = GetComponent<CharacterController>();
        cmpMovimiento = GetComponent<Movimiento>();
        cmpPushBack = GetComponent<PushBackPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            if (!cmpPushBack.IsPushBack && !cmpMovimiento.isEsquivando) //BUG FIX, no puede cambiar de estado si está esquivando o knockback
            {
                if (Input.GetKeyDown(AtaqueLigero) || Input.GetKeyDown(ataqueLigeroJoystick)) //condicion OR, Raton o Joystick activan el ataque
                {
                    goWeapon.GetComponent<WeaponPlayer>().AttackLigeroDamage();
                    
                    if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //BUG CONTROL
                    {
                        cmpMovimiento.movDir = cmpMovimiento.Cam.forward * 2;
                    }
                    transform.rotation = Quaternion.LookRotation(cmpMovimiento.movDir);
                    isAttacking = true;
                    lowAttack1 = true;
                }
                /*
                if (Input.GetKeyDown(AtaquePesado) || Input.GetKeyDown(ataquePesadoJoystick)) //condicion OR, Raton o Joystick activan el ataque
                {
                    cmpCollider.SendMessage("AttackStrongDamage");
                    if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //BUG CONTROL
                    {
                        cmpMovimiento.movDir = cmpMovimiento.Cam.forward * 2;
                    }
                    transform.rotation = Quaternion.LookRotation(cmpMovimiento.movDir);
                    isAttacking = true;
                    strongAttack = true;
                }
                */
            }
        }
    }

    private void OnAnimatorMove()
    {
        if (isAttacking)
        {

            if (lowAttack1)
            {
                cmpAnimator.SetTrigger("AttackLigeroPlayer");
                Vector3 rootPosicion = cmpAnimator.rootPosition;
                Vector3 difPos = rootPosicion - this.transform.position;
                cmpCC.Move(difPos);
            }

            if (strongAttack)
            {
                cmpAnimator.SetTrigger("AttackPesadoPlayer");
                Vector3 rootPosicion = cmpAnimator.rootPosition;
                Vector3 difPos = rootPosicion - this.transform.position;
                cmpCC.Move(difPos);
            }
        }
    }


    public void AnimEventFinishAttackLigero()
    {
        lowAttack1 = false;
        isAttacking = false;
        ResetTriggerAnim();
    }
    public void AnimEventFinishAttackStrong()
    {
        strongAttack = false;
        isAttacking = false;
        ResetTriggerAnim();
    }

    void ResetTriggerAnim()
    {
        //Evitar Bugs
        cmpAnimator.ResetTrigger("AttackStrongPlayer");
        cmpAnimator.ResetTrigger("EsquivarPlayer");
        cmpAnimator.ResetTrigger("PushBackPlayer");

        cmpAnimator.ResetTrigger("AttackLigeroPlayer");

    }
}
