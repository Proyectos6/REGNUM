using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaballeroNpc : MonoBehaviour
{

    [SerializeField] Text caballeroText;
    bool isDentro = false;

    // Start is called before the first frame update
    void Start()
    {

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
                    caballeroText.text = "Hola viajero, ¿tienes las armas para mi?";

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        MisionController.instance.AceptoCaballero();
                    }
                }

                if (MisionController.instance.isCaballero) //FIN MISION
                {
                    caballeroText.text = "Gracias por traerlas, pareces tener alma de esclavo";
                }
            }

        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            caballeroText.gameObject.SetActive(true);
            isDentro = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDentro = false;
            caballeroText.gameObject.SetActive(false);
        }
    }

}
