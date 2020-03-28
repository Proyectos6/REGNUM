using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerArmasAnimaciones : MonoBehaviour
{
    Ataque AT;
    Animator Anim;

    public RuntimeAnimatorController Axe1HController;
    public RuntimeAnimatorController Axe2HController;

    bool Axe1H;
    bool Axe2H;

    public GameObject Hacha1;
    public GameObject Hacha2;

    public float AtaqueL_1HAxe;
    public float AtaqueP_1HAxe;

    public float AtaqueL_2HAxe;
    public float AtaqueP_2HAxe;
    void Awake()
    {
        AT = GetComponent<Ataque>();
        Anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Axe1H = true;
        Axe2H = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("x")) 
        {
            if (Axe1H == true)
            {
                Axe1H = false;
                Axe2H = true;
                Hacha1.SetActive(false);
                Hacha2.SetActive(true);
                AT.TimerAtaqueLigero = AtaqueL_1HAxe;
                AT.TimerAtaquePesado = AtaqueP_1HAxe;
                Anim.runtimeAnimatorController = Axe2HController;
            }
            if (Axe2H == true)
            {
                Axe2H = false;
                Axe1H = true;
                Hacha2.SetActive(false);
                Hacha1.SetActive(true);
                AT.TimerAtaqueLigero = AtaqueL_2HAxe;
                AT.TimerAtaquePesado = AtaqueP_2HAxe;
                Anim.runtimeAnimatorController = Axe1HController;
            }
        }
    }
}
