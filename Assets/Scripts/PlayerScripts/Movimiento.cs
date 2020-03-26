using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
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
    void FixedUpdate()
    {
        float xV = System.Math.Abs (player.velocity.x);
        float zV = System.Math.Abs(player.velocity.z);
        Anim.SetFloat("Velocidad", xV + zV);
        
        if (player.isGrounded)
        {
            movDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        }
        movDir.y -= gravedad * Time.deltaTime;
        player.Move(movDir * velocidad * Time.deltaTime);
        if (Anim.GetBool("AtaqueLigero") == true)
        {
            velocidad = 0;
        }
        else if (Anim.GetBool("AtaquePesado") == true)
        {
            velocidad = 0;
        }
        else
        {
            velocidad = VI;
        }
    }
}
