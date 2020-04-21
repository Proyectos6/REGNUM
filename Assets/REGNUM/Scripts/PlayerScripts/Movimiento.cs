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
    public ParticleSystem andarParticle;
    public ParticleSystem andarParticle2;
   // public GameObject andarcubo1;
    

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
    void FixedUpdate()
    {
        //andarcubo1.SetActive(false);

        andarParticle.Stop();
        andarParticle2.Stop();
        if (player.isGrounded)
        {
            movDir = Cam.forward * Input.GetAxis("Vertical") + Cam.right * Input.GetAxis("Horizontal");
            andarParticle.Play();
            andarParticle2.Play();
            // andarcubo1.SetActive(true);
            Anim.SetFloat("SpeedForward", Input.GetAxis("Vertical"));
            Anim.SetFloat("SpeedRight", Input.GetAxis("Horizontal"));
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
        //Anim.SetFloat("Velocidad", Mathf.Abs(player.velocity.x) + Mathf.Abs(player.velocity.z));
        /*Anim.SetFloat("SpeedForward", Input.GetAxis("Vertical"));
        Anim.SetFloat("SpeedRight", Input.GetAxis("Horizontal"));*/
        //Debug.Log(Mathf.Abs(player.velocity.z));
    }
}
