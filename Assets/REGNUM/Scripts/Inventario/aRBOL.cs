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

    void OnTriggerStay(Collider col)
    {      
 

        if (col.CompareTag("Player") && Input.GetKeyDown("f"))
        {
            Debug.Log("Talando árbol");
            Instantiate(woodDrop, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 90)));
            Destroy(gameObject);
        }
    }
}
