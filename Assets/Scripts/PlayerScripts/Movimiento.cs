using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Collider Golpeando;
    CharacterController player;
    Vector3 movDir;
    float VI;
    public Animator Anim;
    Rigidbody RB;

    public float gravedad;
    public float velocidad = 5f;
    public Transform Cam;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
        VI = velocidad;
    }
    void Update()
    {
        float xV = System.Math.Abs (player.velocity.x);
        float zV = System.Math.Abs(player.velocity.z);
        Anim.SetFloat("Velocidad", xV + zV);
        
        if (player.isGrounded)
        {
            movDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        }
        movDir.y -= gravedad * Time.deltaTime;
        if (Golpeando.enabled == true)
        {
            velocidad = 0;
        }
        else
        {
            velocidad = VI;
        }
        player.Move(movDir * velocidad * Time.deltaTime);
    }
}
