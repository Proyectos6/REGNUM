using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] GameObject goWeapon;
    Animator cmpAnimator;
    CharacterController cmpCC;
    Movimiento cmpMovimiento;
    PushBackPlayer cmpPushBack;

    [SerializeField] Collider cmpColliderWeapon;
    public GameObject paraticleESPADA;

    bool isAttacking = false;
    public bool IsAttacking => isAttacking;
    bool lowAttack1 = false;
    bool strongAttack = false;
    //Teclas para configurar ataque
    KeyCode AtaquePesado = KeyCode.Mouse1; //Input Mapping for Teclado
    KeyCode ataquePesadoJoystick = KeyCode.Joystick1Button4; //Input Mapping for Joystick;
    KeyCode AtaqueLigero = KeyCode.Mouse0; //Input Mapping for Teclado
    KeyCode ataqueLigeroJoystick = KeyCode.Joystick1Button5; //Input Mapping for Joystick;

    bool habilitarSecondHit = false;
    bool secondHit = false;

    AnimatorClipInfo[] currentClip;

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
        if (cmpColliderWeapon != null)
        {
            cmpColliderWeapon.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentClip = cmpAnimator.GetCurrentAnimatorClipInfo(0);


        if (!cmpPushBack.IsPushBack && !cmpMovimiento.isEsquivando) //BUG FIX, no puede cambiar de estado si está esquivando o knockback
        {
            if (Input.GetKeyDown(AtaqueLigero) || Input.GetKeyDown(ataqueLigeroJoystick)) //condicion OR, Raton o Joystick activan el ataque
            {
                if (currentClip[0].clip.name == "FirstHitClip") //Ejecuta Segundo Golpe
                {
                    if (habilitarSecondHit)
                    {
                        secondHit = true;
                        lowAttack1 = false;
                        isAttacking = true;
                    }
                }

                else //Primer Golpe
                {
                    goWeapon.GetComponent<WeaponPlayer>().AttackLigeroDamage();

                    if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //BUG CONTROL
                    {
                        cmpMovimiento.movDir = cmpMovimiento.Cam.forward * 2;
                    }
                    transform.rotation = Quaternion.LookRotation(cmpMovimiento.movDir);
                    isAttacking = true;
                    lowAttack1 = true;
                    habilitarSecondHit = true;
                }
            }

            if (!IsAttacking)
            {
                if (Input.GetKeyDown(AtaquePesado) || Input.GetKeyDown(ataquePesadoJoystick)) //condicion OR, Raton o Joystick activan el ataque
                {
                    goWeapon.GetComponent<WeaponPlayer>().AttackStrongDamage();
                    if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //BUG CONTROL
                    {
                        cmpMovimiento.movDir = cmpMovimiento.Cam.forward * 2;
                    }
                    transform.rotation = Quaternion.LookRotation(cmpMovimiento.movDir);
                    isAttacking = true;
                    strongAttack = true;
                }

            }

        }



    }

    private void OnAnimatorMove()
    {
        if (isAttacking)
        {
            if (lowAttack1 && !secondHit)
            {
                cmpAnimator.SetTrigger("AttackLigeroPlayer");
                /*Vector3 rootPosicion = cmpAnimator.rootPosition;
                Vector3 difPos = rootPosicion - this.transform.position;
                cmpCC.Move(difPos);*/
                paraticleESPADA.SetActive(true);
            }
            if (secondHit)
            {
                lowAttack1 = false;
                cmpAnimator.SetTrigger("SecondHit");

                Vector3 rootPosicion = cmpAnimator.rootPosition;
                Vector3 difPos = rootPosicion - this.transform.position;
                cmpCC.Move(difPos);
                paraticleESPADA.SetActive(true);
            }
            if (strongAttack)
            {
                cmpAnimator.SetTrigger("AttackStrongPlayer");
                Vector3 rootPosicion = cmpAnimator.rootPosition;
                Vector3 difPos = rootPosicion - this.transform.position;
                cmpCC.Move(difPos);
                paraticleESPADA.SetActive(true);
            }
        }
    }


    public void AnimEventFinishAttackLigero()
    {
        habilitarSecondHit = false;
        lowAttack1 = false;
        if (!secondHit)
        {
            isAttacking = false;
        }
        ResetTriggerAnim();
        paraticleESPADA.SetActive(false);
    }
    public void AnimEventFinishSecondHit()
    {
        secondHit = false;
        lowAttack1 = false;
        isAttacking = false;
        ResetTriggerAnim();
        cmpAnimator.ResetTrigger("SecondHit");
        paraticleESPADA.SetActive(false);
    }

    public void AnimEventFinishAttackStrong()
    {
        strongAttack = false;
        isAttacking = false;
        ResetTriggerAnim();
        paraticleESPADA.SetActive(false);
    }

    void ResetTriggerAnim()
    {
        //Evitar Bugs
        cmpAnimator.ResetTrigger("AttackStrongPlayer");
        cmpAnimator.ResetTrigger("EsquivarPlayer");
        cmpAnimator.ResetTrigger("PushBackPlayer");

        cmpAnimator.ResetTrigger("AttackLigeroPlayer");
    }

    public void EventAnimColliderEnabled() //Activa/Desactiva Collider del arma para poder hacer daño.
    {
        cmpColliderWeapon.enabled = !cmpColliderWeapon.enabled;
    }


    public void AnimEventFinishAttackPrimero()
    {
        lowAttack1 = false;
        isAttacking = false;
        ResetTriggerAnim();
        paraticleESPADA.SetActive(false);

        if (secondHit)
        {
            print("ejecuta 2");
            isAttacking = true;
            cmpAnimator.SetTrigger("SecondHit");
        }
        /*
        if (cmpAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            
        }*/
    }
}
