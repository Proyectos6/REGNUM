using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hierro : MonoBehaviour
{
    public GameObject ironDrop;

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && Input.GetKeyDown("f"))
        {
            Instantiate(ironDrop, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
