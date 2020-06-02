using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCCMovimiento : MonoBehaviour
{
    [Header("Físicas")]
    public float velocidadAndar = 3.0F;
    public float velocidadCorrer = 5.0f;
    public float velocidadDeslizar = 10.0f;
    public float aceleracion = 5.0f;
    public float velocidadPegadoAlSuelo = -10;
    public float velocidadRotacion = 90;
    public float velocidadSalto = 5;
    public float gravedad = -9.8f;

    [Header("Input")]
    public string inputAxisMovZ = "Vertical";
    public string inputAxisMovX = "Horizontal";
    public string inputAxisRotY = "Mouse X";
    public string inputAxisRotCameraX = "Mouse Y";


    public Vector3 VelDeslizarGlobal => velDeslizarGlobal;
    Vector3 velXZLocal;
    public Vector3 VelXZLocal => velXZLocal;
    Vector3 velDeslizarGlobal;
    public float VelocidadAngular => velocidadAngular;
    float velocidadAngular;
    public float VelocidadY => velocidadY;
    float velocidadY;

    float anguloCamara = 0;

    protected CharacterController cmpCC;
    protected Camera cmpCamera;

    
    bool deslizando = false;
    bool saltando = false;
    public bool Saltando => saltando;

    [HideInInspector] public GameObject pechoPlayer;


    protected virtual void Awake()
    {
        cmpCC = GetComponent<CharacterController>();
        cmpCamera = GetComponentInChildren<Camera>();
        //pechoPlayer = GameObject.FindGameObjectWithTag("PechoPlayer");
    }


    void Update()
    {
        AplicarGravedad();
        Deslizar();
        Mover();
        MantenersePegadoAlSuelo();
    }

    void Deslizar()
    {
        deslizando = false;

        Vector3 direccionDeslizamiento = Vector3.zero;
        RaycastHit infoImpacto;
        if (Physics.SphereCast(this.transform.position + cmpCC.center, 0.5f, Vector3.down, out infoImpacto, 1))
        {
            Vector3 normalSuperficie = infoImpacto.normal;
            Debug.DrawRay(infoImpacto.point, normalSuperficie, Color.green, 1);
            float angulo = Vector3.Angle(normalSuperficie, Vector3.up);
            if (angulo > cmpCC.slopeLimit)
            {
                deslizando = true;

                direccionDeslizamiento = normalSuperficie;
                direccionDeslizamiento.y = 0;
                direccionDeslizamiento.Normalize();
            }
        }

        if (deslizando) { velDeslizarGlobal = Vector3.Lerp(velDeslizarGlobal, direccionDeslizamiento * velocidadDeslizar, Time.deltaTime * 2); }
        else { velDeslizarGlobal = Vector3.zero; }
    }
    void Mover()
    {
        float magnitudVelocidad = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadAndar;

        float inputZ = string.IsNullOrEmpty(inputAxisMovZ) ? 0 : Input.GetAxis(inputAxisMovZ);
        float inputX = string.IsNullOrEmpty(inputAxisMovX) ? 0 : Input.GetAxis(inputAxisMovX);
        Vector3 inputNormalizado = new Vector3(inputX, 0, inputZ);
        if (inputNormalizado.magnitude > 1) { inputNormalizado.Normalize(); }

        Vector3 velXZLocalDeseada = inputNormalizado * magnitudVelocidad;
        velXZLocal = Vector3.MoveTowards(velXZLocal, velXZLocalDeseada, aceleracion * Time.deltaTime);
        AplicarMovimiento();
    }
    protected virtual void AplicarMovimiento() 
    {
        Vector3 velXZGlobal = transform.TransformDirection(velXZLocal);
        Vector3 velocidadTotal = velXZGlobal + velDeslizarGlobal + Vector3.up * velocidadY;
        cmpCC.Move(velocidadTotal * Time.deltaTime);
    }
    void AplicarGravedad() 
    {
        velocidadY += gravedad * Time.deltaTime;
    }
    void MantenersePegadoAlSuelo() 
    {
        if (cmpCC.isGrounded) { velocidadY = velocidadPegadoAlSuelo; }
    }
}
