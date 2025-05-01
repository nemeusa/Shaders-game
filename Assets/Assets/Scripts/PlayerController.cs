using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float rangoInteraccion = 3f;
    public LayerMask capaInteractuable;
    public LayerMask capaInteractuableVitrina;
    bool _isHand;

    private Rigidbody rb;
    private Camera cam;

    private List<IInteractable> resaltados = new List<IInteractable>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 direccionDeseada = forward * vertical + right * horizontal;
        Vector3 movimiento = direccionDeseada.normalized * velocidad * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movimiento);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            IntentarInteractuar();

        if (Input.GetKeyDown(KeyCode.Q))
            MarcarInteractuables();

        if (Input.GetKeyUp(KeyCode.Q))
            DesmarcarInteractuables();
    }

    void IntentarInteractuar()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, rangoInteraccion, capaInteractuable))
        {
            IInteractable interactuable = hit.collider.GetComponent<IInteractable>();
            if (interactuable != null)
            {
                interactuable.Interact();
                _isHand = true;
            }
        }
        if (Physics.Raycast(ray, out RaycastHit hit2, rangoInteraccion, capaInteractuableVitrina) && _isHand)
        {
            IInteractable interactuable = hit.collider.GetComponent<IInteractable>();
            if (interactuable != null)
                interactuable.Interact2();
        }
    }

    void MarcarInteractuables()
    {
        DesmarcarInteractuables(); // Limpiar lo anterior

        Collider[] colliders = Physics.OverlapSphere(transform.position, rangoInteraccion, capaInteractuable);
        foreach (Collider col in colliders)
        {
            Vector3 dirToObj = (col.transform.position - cam.transform.position).normalized;
            float dot = Vector3.Dot(cam.transform.forward, dirToObj);

            if (dot > 0.5f) // Solo los que están al frente
            {
                IInteractable interactuable = col.GetComponent<IInteractable>();
                if (interactuable != null)
                {
                    interactuable.Highlight(true);
                    resaltados.Add(interactuable);
                }
            }
        }
    }

    void DesmarcarInteractuables()
    {
        foreach (IInteractable obj in resaltados)
        {
            if (obj != null)
                obj.Highlight(false);
        }
        resaltados.Clear();
    }
}
