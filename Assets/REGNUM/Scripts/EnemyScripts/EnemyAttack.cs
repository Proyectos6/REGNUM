using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float rangeHit = 5;
    [SerializeField] float tiempoEntreAtaques = 3;
    public float tiempoActualGolpe;
    [SerializeField] float probStrongAtack = 0.2f;
    float timeNextAttack;

    public bool isAttacking = false;

    VidaPlayer playerVida;
    Animator cmpAnimator;



    [SerializeField] CapsuleCollider cmpWeaponCollider;
    bool collWeaponEnable = false;

    bool isDie = false;


    private void Awake()
    {
        playerVida = FindObjectOfType<VidaPlayer>();
        cmpAnimator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        tiempoActualGolpe = tiempoEntreAtaques;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distancePlayer = Vector3.Distance(this.transform.position, playerVida.transform.position);
        if (!isDie)
        {
            if (distancePlayer < rangeHit)
            {
                if (tiempoActualGolpe <= 0)
                {
                    this.transform.LookAt(playerVida.transform.position);
                    Atacar();
                }
                else
                {
                    tiempoActualGolpe -= Time.deltaTime;
                }
            }
        }
    }

    void Atacar()
    {
        isAttacking = true;

        bool ataqueFuerte = (Random.value < probStrongAtack);
        if (ataqueFuerte)
        {

        }
        else
        {
            cmpAnimator.SetTrigger("Attack");
        }
    }

    //Change Collider Active Component During The Attack
    void SwitchColliderEnabled(int isEnabled)
    {
        if (isEnabled == 0)
        {
            collWeaponEnable = false;
            cmpWeaponCollider.enabled = collWeaponEnable;//Active/Disabled Weapon Collider
        }
        if (isEnabled == 1)
        {
            collWeaponEnable = true;
            cmpWeaponCollider.enabled = collWeaponEnable;//Active/Disabled Weapon Collider
        }
    }

    public void AnimEventFinishAttack()
    {
        isAttacking = false;
        tiempoActualGolpe = tiempoEntreAtaques;
        cmpAnimator.ResetTrigger("Attack");
    }

    void EnemyDie()
    {
        isDie = true;
    }
}
