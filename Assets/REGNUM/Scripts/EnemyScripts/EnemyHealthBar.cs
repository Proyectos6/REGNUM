using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform barraVerde;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetSize( float vidaBarra)
    {
        barraVerde.localScale = new Vector3(vidaBarra, 1);
    }
}
