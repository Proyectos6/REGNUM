using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    Collider cmpCollider;

    [SerializeField] float damageWeaponLigero=10;
    [SerializeField] float damageWeaponStrong = 50;
    float damageWeapon;

    [SerializeField]Animator cmpAnimator;

    private void Awake()
    {
        cmpCollider = GetComponent<Collider>();
        //cmpAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cmpCollider.enabled = false;
    }

 
    public void EventAnimColliderEnabled()
    {
        cmpCollider.enabled = !cmpCollider.enabled;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            print(damageWeapon);
            other.GetComponent<VidaEnemy>().TakeDamage(damageWeapon);
        }
    }

    public void AttackStrongDamage()
    {
        damageWeapon = damageWeaponStrong;
    }
    public void AttackLigeroDamage()
    {
        damageWeapon = damageWeaponLigero;
    }


}
