using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float velocitywalk = 5f; // Trnaslate speed when walking with W and S
    public float velocityrun = 4.5f; // Translate speed when running with W and S + Left Shift

    [Header("Rotation Settings")]
    public float velocityrotation = 150f; //Translate Configurarion when rotating with A and D

    [Header("Jump & Gravity Settings")]
    public float jumpHeight = 2.5f;
    public float gravity = -9.81f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

     
        float rotacionInput = Input.GetAxis("Horizontal"); 
        transform.Rotate(0f, rotacionInput * velocityrotation * Time.deltaTime, 0f);


        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocityrun : velocitywalk;

        float movimientoInput = Input.GetAxis("Vertical"); // Teclas W y S

     
        Vector3 directionMovement = transform.forward * movimientoInput;
        Vector3 movement = directionMovement * velocidadActual * Time.deltaTime;


        if (controller != null)
        {
            controller.Move(movement);
        }

        // 4. Dectetion When The Jump Pressed based in the Input )
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Salto Detectado");
        }

        //Jump Dectetion 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump Detected");
        }
        // Apply Gravity
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}