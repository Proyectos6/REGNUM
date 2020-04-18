using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    VidaBase vida;
    [SerializeField] Image barraVida;

    private void Awake()
    {
        vida = GetComponent<VidaBase>();
    }


    void Update()
    {
        float vidaActual = vida.VidaActual;
        float vidaMaxima = vida.VidaMax;
        float porcentajeVida = vidaActual / vidaMaxima;
        if (barraVida != null)
        {
            barraVida.fillAmount = porcentajeVida;
        }
    }
}
