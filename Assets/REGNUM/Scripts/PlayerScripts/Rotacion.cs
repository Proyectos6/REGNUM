using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    Vector3 mousePos;
    Camera cam;
    Rigidbody rid;
    Ataque Ataque;
    public GameObject[] Enemigos;

    public float velocidadRotacion = 360;
    void Awake()
    {
        rid = this.GetComponent<Rigidbody>();
        cam = Camera.main;
        Ataque = this.GetComponent<Ataque>();
        Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
    }
    void Update() 
    {
        if (Ataque.Atacando == false)
        {
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {

                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                pointToLook.y = transform.position.y;
                Quaternion mirar = Quaternion.LookRotation(pointToLook - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, mirar, velocidadRotacion * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {

    }


}



