using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVida : MonoBehaviour
{
    public float vida;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
