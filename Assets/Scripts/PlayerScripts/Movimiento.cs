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
    Ataque AT;

    public float gravedad;
    public float velocidad = 5f;
    public Transform Cam;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
        AT = GetComponent<Ataque>();
        
    }
    private void Start()
    {
        VI = velocidad;
    }
    void Update()
    {
        
        if (player.isGrounded)
        {
            movDir.y = 0;
            movDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        }
        if (player.isGrounded == false) { movDir.y -= gravedad * Time.deltaTime; }
        if (movDir.magnitude > 1)
        {
            movDir.Normalize();
        }
        if (AT.Atacando == false)
        {
            player.Move(movDir * velocidad * Time.deltaTime);
        }
        Anim.SetFloat("Velocidad", Mathf.Abs(player.velocity.x) + Mathf.Abs(player.velocity.y));
    }
}
