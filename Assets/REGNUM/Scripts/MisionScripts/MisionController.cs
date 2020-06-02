﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MisionController : MonoBehaviour
{

    [SerializeField]Text misionText;
    public bool isHerrero = false;
    public bool isCaballero = false;
   // GameObject goPlayer, goHerrero, goCaballero;

    public static MisionController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        misionText.text = "Habla con el herrero";
    }

    // Update is called once per frame
    void Update()
    {
    
    }





    public void AceptoHerrero()
    {
        isHerrero = true;
        misionText.text = "Lleva las armas al caballero";
    }

    public void AceptoCaballero()
    {
        isCaballero = true;
        misionText.text = "Has acabado la mision!";
    }
}
