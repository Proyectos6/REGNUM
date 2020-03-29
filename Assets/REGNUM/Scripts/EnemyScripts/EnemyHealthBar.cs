using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform barraVerde;
    public Transform barraRoja;
    GameObject Cam;
    // Start is called before the first frame update
    void Awake()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void Update()
    {
        barraVerde.LookAt(Cam.transform);
        barraRoja.LookAt(Cam.transform);
    }

    // Update is called once per frame
    public void SetSize( float vidaBarra)
    {
        barraVerde.localScale = new Vector3(vidaBarra, 1);
    }
}
