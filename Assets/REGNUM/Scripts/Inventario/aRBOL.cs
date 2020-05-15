using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aRBOL : MonoBehaviour
{

    public GameObject woodDrop;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(woodDrop, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
