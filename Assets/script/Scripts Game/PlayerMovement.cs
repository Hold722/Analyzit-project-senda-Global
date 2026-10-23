using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movespeed = 5f;
    public float rotationSpeed = 70f;

    [Header("Jump & Gravity Settings")]
    public float jumpHeight = 2.5f;
    public float gravity = -9.81f; // Fuerza de gravedad negativa para simular la caída

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    void Start()
    {
        // Componentes necesarios para el movimiento del jugador
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Revisa si el jugador está tocando el suelo
        isGrounded = controller.isGrounded;

        // Resetear la velocidad vertical si el jugador está en el suelo y se está moviendo hacia abajo
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Movement Input settings
        float movex = Input.GetAxis("Horizontal"); // A and D
        float movez = Input.GetAxis("Vertical");   // W and S

        // Calcular la direccion exacta del movimiento basado en la orientación del jugador
        Vector3 moveDirection = transform.forward * movez + transform.right * movex;
        controller.Move(moveDirection * movespeed * Time.deltaTime);

        // Rotation Settings
        if (movex != 0)
        {
            transform.rotation *= Quaternion.Euler(0, movex * rotationSpeed * Time.deltaTime, 0);
        }


        // Dectesion de salto 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Physics formula to calculate precise velocity needed for a specific jump height
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplicar la gravedad a la velocidad vertical del jugador
        playerVelocity.y += gravity * Time.deltaTime;

        // Ejecutar el movimiento del jugador basado en la velocidad vertical calculada
        controller.Move(playerVelocity * Time.deltaTime);
    }
}