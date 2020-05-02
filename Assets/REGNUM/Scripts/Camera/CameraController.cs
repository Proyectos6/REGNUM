﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    Transform target;
    GameObject Player;
    public Transform CamFija;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 10f;
    [SerializeField] float yawSpeedJoystick = 50;

    private float currentZoom = 10f;
    private float currentYaw = 0f;


    Rotacion Rot;
    Transform CamNF;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Player.transform;
        Rot = Player.GetComponent<Rotacion>();
    }

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        float valorRotacionMouse = Input.GetAxis("CameraRoot") * yawSpeed * Time.deltaTime; //En caso de Rotar Camera con Raton, Añado valor de la rotacion en variable;
        float valorRotacionJoy = Input.GetAxis("CameraRootJoy") * yawSpeedJoystick * Time.deltaTime; //Rotacion Joystick, guardo variable 

        currentYaw -= (valorRotacionMouse + valorRotacionJoy); //Movimiento de la camara a traves de Raton y/o Mando. Pa elegir

    }

    void LateUpdate()
    {
        if (Rot.Fijando == false)
        {
            transform.position = target.position - offset * currentZoom;
            transform.LookAt(target.position + Vector3.up * pitch);
            transform.RotateAround(target.position, Vector3.up, currentYaw);
        }
        if (Rot.Fijando == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, CamFija.position, 50 * Time.deltaTime);
            transform.LookAt(target.position + Vector3.up * pitch);
        }
    }
}
