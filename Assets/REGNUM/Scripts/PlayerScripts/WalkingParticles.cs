using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingParticles : MonoBehaviour
{
    [SerializeField] Transform rightFoot, leftFoot;

    Transform pieActual;

    public GameObject prefabPaticulasAndar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EventAnimInstanciarParticulaAndar(int pie)
    {
        if (pie == 0)
        {
            pieActual = rightFoot;
            // print("Der");
        }
        if (pie == 1)
        {
            pieActual = leftFoot;
            //print("Izqui");
        }

        GameObject particula = Instantiate(prefabPaticulasAndar, pieActual.position, Quaternion.identity);
        Destroy(particula, 2);
        particula.transform.parent = null;
    }

}
