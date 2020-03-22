using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    GameObject Player;
    private Vector3 cameraOffset;
    private float rotationSpeed;
    public float ValorRotacion;
    Camera Cam;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        cameraOffset = transform.position - Player.transform.position;
        Cam = GetComponent<Camera>();
    }
    private void Update()
    {
        Cam.fieldOfView = Cam.fieldOfView - (Input.GetAxis("Mouse ScrollWheel") * 10);
        if (Input.GetKeyDown("q"))
        {
            rotationSpeed = -ValorRotacion;
        }       
        if (Input.GetKeyUp("q"))
        {
            rotationSpeed = 0;
        }
        if (Input.GetKeyDown("e"))
        {
            rotationSpeed = ValorRotacion;
        }
        if (Input.GetKeyUp("e"))
        {
            rotationSpeed = 0;
        }
        if (Cam.fieldOfView > 60)
        {
            Cam.fieldOfView = 60;
        }
        if (Cam.fieldOfView < 20)
        {
            Cam.fieldOfView = 20;
        }
    }
    void LateUpdate()
    {
        Quaternion camTurnAngle = Quaternion.AngleAxis(rotationSpeed, Vector3.up);
        cameraOffset = camTurnAngle * cameraOffset;
        transform.LookAt(Player.transform);
        Vector3 newPos = Player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, 1f);
    }
}
