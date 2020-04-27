using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SangrePlayer : MonoBehaviour
{
    public float velocidadChange;

    public float maxAlpha, minAlpha, actualAlpha;

    SpriteRenderer sprRender;
    GameObject sangre;
     public Image imagen;



    Vector4 cambioColor;

    public bool activarContador = false;



    // <>       Creo que es la linea de codigo mas util e importante de todo el codigo

    // Start is called before the first frame update
    void Start()
    {
        sprRender = GetComponentInChildren<SpriteRenderer>();
        actualAlpha = maxAlpha;
        cambioColor = new Color(1, 1, 1, actualAlpha);
        sprRender.color = cambioColor;

        sprRender.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (activarContador == true) //el contador es el propio alpha del objeto que marca cuando llega al mínimo (desaparece) se desactiva el contador.
        {
            //Cuando se le activa el evento se setea al maximo  el valor de Alpha para que se vea.
            //actualAlpha = maxAlpha; //seteo que el valor del alpha sea el maximo para que se vea.
            imagen.gameObject.SetActive(true);
            //sprRender.gameObject.SetActive(true); //activo el objeto para que se vea
            
           
            

            actualAlpha -= velocidadChange * Time.deltaTime; //resto valor al alpha actual
            cambioColor = new Color(1, 1, 1, actualAlpha); //guardo el valor del color
            //sprRender.color = cambioColor; //actualiza el color
                                           //print(actualAlpha + " es el alpha de desaparecer");


            if (actualAlpha <= minAlpha)
            {
                actualAlpha = minAlpha;
                activarContador = false;//salgo del bucle;
                imagen.gameObject.SetActive(false);
               

               // sprRender.gameObject.SetActive(false);
                //salgo del bucle;
                

                /*
                // actualAlpha = minAlpha;//dejo el alpha al minimo para que no se vea.

                cambioColor = new Color(1, 1, 1, actualAlpha); //guardo el valor del color
                imgRender.color = cambioColor; //actualiza el color
                */
            }


        }

    }


    public void ApareceSangre()
    {

        actualAlpha = maxAlpha;
        activarContador = true;
        print("HE recibido el apareceSangre");
    }
}
