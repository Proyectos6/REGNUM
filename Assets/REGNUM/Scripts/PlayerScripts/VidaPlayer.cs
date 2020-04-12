using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : VidaBase
{

    protected override void Morir()
    {
        //base.Morir();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    /*
    [SerializeField] float playerMaxHealth = 50;
    float actualHealth;

    HealthBarPlayer cmpHealthbar;

    private void Awake()
    {
        cmpHealthbar = GameObject.FindGameObjectWithTag("PlayerHealthbar").GetComponent<HealthBarPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        actualHealth = playerMaxHealth;
        float inicialSliderValue = actualHealth / playerMaxHealth;
        cmpHealthbar.SetSliderHealthbarSize(inicialSliderValue);
    }


    //COMPORTAMIENTO- PERDER VIDA
    public void TakeDamagePlayer(float damageFromWeapon)
    {
        actualHealth -= damageFromWeapon;

        if (actualHealth <= 0)
        {
            print("YOU ARE DIE!");
        }

        float healthSliderValue = actualHealth / playerMaxHealth;
        cmpHealthbar.SetSliderHealthbarSize(healthSliderValue);

    }
    */
}
