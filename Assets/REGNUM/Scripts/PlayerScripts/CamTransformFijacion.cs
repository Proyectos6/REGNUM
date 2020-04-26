using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransformFijacion : MonoBehaviour
{
    GameObject Cam;
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z);
        transform.rotation = new Quaternion(Cam.transform.rotation.y, 0, 0, Cam.transform.rotation.w);
    }
}
