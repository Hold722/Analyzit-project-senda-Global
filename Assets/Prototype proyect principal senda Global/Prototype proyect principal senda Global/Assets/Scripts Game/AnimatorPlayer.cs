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
        // 1. SALTO INDEPENDIENTE: Funciona estando quieto, caminando o corriendo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // 2. MOVIMIENTO (Correr, Caminar o Quieto)
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            Run();
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            WalkSpeed();
        }
        else
        {
            Idle();
        }
    }

    void Idle()
    {
        animator.SetFloat("Speed", 0f);
    }

    void WalkSpeed()
    {
        animator.SetFloat("Speed", walkSpeed);
    }

    void Run()
    {
        animator.SetFloat("Speed", 1f);
    }

    void Jump()
    {
        animator.SetTrigger("Jump");

        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}