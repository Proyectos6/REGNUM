using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HerreroNpc : MonoBehaviour
{
    [SerializeField]Text herreroText;
    //bool isAcceptHerrero = false;
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
            if (!MisionController.instance.isHerrero) //no has hablado con el herrero
            {
                herreroText.text = "Hola viajero, ¿podrías llevar estas armas al caballero Wallace?";
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
                    herreroText.text = "Deja esas yerbas y dale ya las armas!";
                }
                if (MisionController.instance.isCaballero)   //Herrero y caballero
                {
                    herreroText.text = "Eres el chaca del videojuego, gracias por moverte jeje";
                }
            }  
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {            
            herreroText.gameObject.SetActive(true);
            isDentro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            herreroText.gameObject.SetActive(false);
            isDentro = false;
        }
    }

}
