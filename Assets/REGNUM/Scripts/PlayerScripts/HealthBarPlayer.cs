using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    Slider cmpSlider;

    private void Awake()
    {
        cmpSlider = GetComponent<Slider>();
    }


    public void SetSliderHealthbarSize(float valueHealth) //CAMBIA EL VALOR DEL SLIDER, MODIFICA VIDA EN CANVAS. ACTIVADO MEDIANTE SCRIPT "VidaPlayer". 
    {
        cmpSlider.value = valueHealth;
    }

}
