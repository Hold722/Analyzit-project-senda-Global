using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    public Animator animator;

    public float walkSpeed = 0.5f;
    public float runSpeed = 1.5f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    [Header("Sonido Pasos")]
    public AudioSource audioSource;
    public float tiempoEntrePasos = 0.5f;
    private float timerPasos;

    [Header("Sonido Salto")]
    public AudioSource saltoAudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && isMoving;

        if (isRunning)
        {
            animator.SetFloat("Speed", runSpeed);
            ReproducirPasos(tiempoEntrePasos * 0.65f);
        }
        else if (isMoving)
        {
            animator.SetFloat("Speed", walkSpeed);
            ReproducirPasos(tiempoEntrePasos);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            timerPasos = 0f;
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void ReproducirPasos(float intervalo)
    {
        if (audioSource == null) return;

        timerPasos -= Time.deltaTime;
        if (timerPasos <= 0f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            timerPasos = intervalo;
        }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");

        if (saltoAudioSource != null)
        {
            saltoAudioSource.Play();
        }

        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}