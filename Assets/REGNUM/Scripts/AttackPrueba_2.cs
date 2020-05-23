using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Invector.vCharacterController
{
    
    public class AttackPrueba_2 : vCharacter
    {
        //Cosas del arma
        [SerializeField]
        Collider cmpColliderWeapon;
        [SerializeField]
        GameObject goWeapon;
        Animator cmpAnimator;

        CharacterController cmpCC;

        //booleanos 
        bool isAttacking = false;

        //Teclas de configuración de ataque ligero y pesado tanto en teclado como en mando de consola
        KeyCode AtaquePesado = KeyCode.Mouse1; //Input Mapping for Teclado
        KeyCode ataquePesadoJoystick = KeyCode.Joystick1Button4; //Input Mapping for Joystick;
        KeyCode AtaqueLigero = KeyCode.Mouse0; //Input Mapping for Teclado
        KeyCode ataqueLigeroJoystick = KeyCode.Joystick1Button5; //Input Mapping for Joystick;

        public vThirdPersonController TPController;
        vThirdPersonMotor TPMotor;

        [SerializeField]
        Rigidbody rbd;

         

        private void Awake()
        {
            cmpAnimator = GetComponent<Animator>();
            cmpCC = GetComponent<CharacterController>();
            rbd = GetComponent<Rigidbody>();
        }

        new void Start()
        {
            TPMotor = GetComponent<vThirdPersonMotor>();
        }

        void Update()
        {
            AtaquePrueba();
        }

        void AnimEventFinalAtaque()
        {
            isAttacking = false;
            SendMessage("DesactivarAtaque");
            VelocidadNormalVuelta();
        }

        void AtaquePrueba()
        {
            if (isAttacking == false)
            {
                if (Input.GetKeyDown(AtaqueLigero) || Input.GetKeyDown(ataqueLigeroJoystick))
                {
                    //Animación de ataque
                    cmpAnimator.CrossFadeInFixedTime("AtaqueLigero1HAxe", 0.1f);

                    isAttacking = true;

                    //Evita que el jugador se mueva mientras ataca
                    /*Vector3 rootPosicion = cmpAnimator.rootPosition;
                    Vector3 difPos = rootPosicion - this.transform.position;
                    cmpCC.Move(difPos);*/

                    SendMessage("ActivarAtaque");

                    if (Input.GetKeyDown(AtaqueLigero) || Input.GetKeyDown(ataqueLigeroJoystick))
                    {
                        //Animación de ataque
                        cmpAnimator.CrossFadeInFixedTime("AtaqueLigero1HAxe", 0.1f);

                        isAttacking = true;

                        //Evita que el jugador se mueva mientras ataca
                        //Vector3 rootPosicion = cmpAnimator.rootPosition;
                        //Vector3 difPos = rootPosicion - this.transform.position;
                        //cmpCC.Move(difPos);

                        SendMessage("ActivarAtaque");
                        VelocidadACero();
                    }
                }

                VelocidadNormalVuelta();
            }     
        }

        void VelocidadACero()
        {           
            SendMessage("VelocidadNula");                            
        }

        void VelocidadNormalVuelta()
        {          
            SendMessage("VelocidadNormal");               
        }

        void RigidbodyOut()
        {
            //rbd.enabled = false;
        }
    }
}
