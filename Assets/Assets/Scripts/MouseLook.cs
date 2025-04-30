using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensibilidad = 100f;
    public Transform cuerpoJugador;

    private float rotacionX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Evita girar 360° vertical

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }
}
