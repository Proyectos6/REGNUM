using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaballeroNpc : MonoBehaviour
{

    [SerializeField] Text caballeroText;
    bool isDentro = false;
    [SerializeField]
    GameObject panel;

    // Start is called before the first frame update
     void Start()
    {
        panel.SetActive(false);
        caballeroText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDentro)
        {
            if (!MisionController.instance.isHerrero) //No hablaste con herrero
            {
                caballeroText.text = "Hola viajero, busca al herrero!";
            }
            if (MisionController.instance.isHerrero) //Ya hablaste con herrero
            {
                if (!MisionController.instance.isCaballero) //Aun no hablaste con caballero
                {
                    caballeroText.text = "Hola viajero, ¿te manda el herrero?";

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        MisionController.instance.AceptoCaballero();
                    }
                }

                if (MisionController.instance.isCaballero) //FIN MISION
                {
                    caballeroText.text = "Aquí tienes tu espada, puedes equipartela en el inventario";
                }
            }

        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(true);
            caballeroText.gameObject.SetActive(true);
            isDentro = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
            isDentro = false;
            caballeroText.gameObject.SetActive(false);
        }
    }

}
