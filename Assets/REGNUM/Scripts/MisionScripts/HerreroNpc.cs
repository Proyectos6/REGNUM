using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HerreroNpc : MonoBehaviour
{
    [SerializeField]Text herreroText;
    //bool isAcceptHerrero = false;
    bool isDentro = false;
    [SerializeField]
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        herreroText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDentro)
        {
            if (!MisionController.instance.isHerrero) //no has hablado con el herrero
            {
                herreroText.text = "Hola viajero, ¿podrías ir a hablar con el caballero Wallace?";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //isAcceptHerrero = true;
                    MisionController.instance.AceptoHerrero();
                    herreroText.text = "Gracias, te estará esperando";
                }             
            }

            if (MisionController.instance.isHerrero) //Has hablado con el herrero
            {
                if (!MisionController.instance.isCaballero)// aun no viste al ccaballero
                {
                    herreroText.text = "Creo que tiene un arma para ti";
                }
                if (MisionController.instance.isCaballero)   //Herrero y caballero
                {
                    herreroText.text = "¡A combatir, a qué esperas!";
                }
            }  
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(true);
            herreroText.gameObject.SetActive(true);
            isDentro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
            herreroText.gameObject.SetActive(false);
            isDentro = false;
        }
    }

}
