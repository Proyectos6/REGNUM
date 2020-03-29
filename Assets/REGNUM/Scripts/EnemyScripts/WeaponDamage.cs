using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{

    [SerializeField] float damageWeapon = 10;

    //DEAL DAMAGE TO PLAYER
    private void OnTriggerEnter(Collider other)
    {
        print("colisiono " + other.name);
        if (other.gameObject.tag == "Player")
        {
            print("TOCADOO!");
            other.gameObject.GetComponent<VidaPlayer>().TakeDamagePlayer(damageWeapon);
        }
    }



}
