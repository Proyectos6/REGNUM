using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    Vector3 mousePos;
    Camera cam;
    Rigidbody rid;
    void Start()
    {
        rid = this.GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    void Update() 
    {
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        
    }
    

}



