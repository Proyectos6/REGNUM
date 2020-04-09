using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaSangre : MonoBehaviour
{
    public ParticleSystem particulas;
    public GameObject jugador;
    public GameObject cubo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Sangrando");
            Sangrar();
        }
    }

    void Sangrar()
    {
        ParticleSystem sangre = Instantiate(particulas, cubo.transform.position, cubo.transform.rotation);
        sangre.GetComponent<ParticleSystem>().Play();
    }
}


