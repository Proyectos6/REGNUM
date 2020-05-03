 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{

    
    [SerializeField] float damageWeaponLigero=10;
    [SerializeField] float damageWeaponStrong = 50;
    float damageWeapon;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
