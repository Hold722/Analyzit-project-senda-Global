using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    public Animator animator;

    public float walkSpeed = 0.5f;
    public float runSpeed = 1.5f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. SALTO CON TRIGGER (Aquí mandamos a llamar la función)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); // <--- Línea donde se ejecuta la función de salto
        }

        // 2. DETECCIÓN DE MOVIMIENTO
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && isMoving;

        // 3. ASIGNACIÓN DE VELOCIDAD AL ANIMATOR
        if (isRunning)
        {
            animator.SetFloat("Speed", runSpeed);
        }
        else if (isMoving)
        {
            animator.SetFloat("Speed", walkSpeed);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    // ==========================================
    // PON LA FUNCIÓN DE SALTO AQUÍ (Al final del script)
    // ==========================================
    void Jump()
    {
        animator.SetTrigger("Jump");

        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}