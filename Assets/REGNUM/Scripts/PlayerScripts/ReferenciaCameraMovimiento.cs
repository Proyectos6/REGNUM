using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenciaCameraMovimiento : MonoBehaviour
{
    GameObject Cam;
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void FixedUpdate()
    {
        transform.position = Cam.transform.position;
        transform.rotation = new Quaternion(0, Cam.transform.rotation.y, 0, Cam.transform.rotation.w);
    }
}
