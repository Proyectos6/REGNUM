using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    CharacterController player;
    Vector3 movDir;
    public float gravedad;

    public float velocidad = 5f;
    public Transform Cam;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (player.isGrounded)
        {
            movDir = Cam.forward * Input.GetAxis("Vertical") + Cam.right * Input.GetAxis("Horizontal");
        }
        movDir.y -= gravedad * Time.deltaTime;
        player.Move(movDir * velocidad * Time.deltaTime);
    }
}
