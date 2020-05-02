using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    CharacterController player;
    public Vector3 movDir;
    float VI;
    public Animator Anim;
    public ParticleSystem andarParticle;
    public ParticleSystem andarParticle2;
    // public GameObject andarcubo1;

    public float gravedad;
    public float velocidad = 5f;
    public Transform Cam;

    public bool isEsquivando = false;

    public bool usarRootMotion = true;

    PushBackPlayer cmpPushBackPlayer;
    Rigidbody RB;
    AttackPlayer cmpAttack;
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
        cmpPushBackPlayer = GetComponent<PushBackPlayer>();
        cmpAttack = GetComponent<AttackPlayer>();
    }
    private void Start()
    {
        VI = velocidad;
    }


    void Update()
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

        }

        AplicarGravedad();

        if (movDir.magnitude > 1)
        {
            movDir.Normalize();
        }

        if (!isEsquivando && !cmpPushBackPlayer.IsPushBack)
        {
            if (!cmpAttack.IsAttacking)
            {
                ComenzarEsquivar();

                MovimientoPlayer();
            }
        }
    }

    private void AplicarGravedad()
    {
        if (player.isGrounded == false) { movDir.y -= gravedad * Time.deltaTime; }
    }

    private void MovimientoPlayer()
    {
        Anim.SetFloat("SpeedForward", Input.GetAxis("Vertical"));
        Anim.SetFloat("SpeedRight", Input.GetAxis("Horizontal"));
        player.Move(movDir * velocidad * Time.deltaTime);

    }

    void ComenzarEsquivar()
    {
        //if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button0)) Teclas configuradaas en InputManager-> EsquivarInput       
        if (Input.GetButtonDown("EsquivarInput"))
        {
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //BUG CONTROL
            {
                movDir = Cam.forward * 2;
            }

            transform.rotation = Quaternion.LookRotation(movDir);
            isEsquivando = true;
            SendMessage("InmortalOn");
        }
    }

    public void AnimEventFinishEsquivar()
    {
        isEsquivando = false;
        SendMessage("InmortalOff");
        Anim.ResetTrigger("EsquivarPlayer");
    }

    private void OnAnimatorMove()
    {
        if (isEsquivando)
        {
            //Vector3 rootRotation = direccionEsquivar;
            Vector3 rootPosicion = Anim.rootPosition;
            Vector3 difPos = rootPosicion - this.transform.position;
            //transform.Translate(difPos, Space.World);
            player.Move(difPos);
            Anim.SetTrigger("EsquivarPlayer");
        }
    }
}

