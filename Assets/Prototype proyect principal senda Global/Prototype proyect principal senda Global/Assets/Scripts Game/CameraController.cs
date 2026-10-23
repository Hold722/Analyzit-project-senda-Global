using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public float distance = 6f;
    public float height = 2f;

    public float rotationSpeed = 120f;

    private float currentYaw = 0;

    void Start()
    {
        // Esto oculta el cursor y lo bloquea en el centro de la pantalla como en GTA o Fortnite
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Lee el movimiento del mouse libremente, sin pedir clicks de nada
        float mouseX = Input.GetAxis("Mouse X");

        // Acumula la rotación
        currentYaw += mouseX * rotationSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Calcula la rotación
        Quaternion rotation = Quaternion.Euler(0f, currentYaw, 0f);

        // Define el offset de distancia y altura
        Vector3 offset = new Vector3(0, height, -distance);

        // Posiciona la cámara orbitando al personaje
        transform.position = target.position + rotation * offset;

        // Hace que la cámara mire fijamente al personaje
        transform.LookAt(target);
    }
}
