using UnityEngine;
using UnityEngine.AI;

public class PatasolaMovement : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 15f;       // Cuánto salta hacia arriba
    public float jumpInterval = 1.5f;   // Cada cuántos segundos da un salto

    [Header("Visual Juice (Optional)")]
    public Transform visualModel;       // Si quieres que solo salte el modelo 3D y no el NavMesh entero
    public float bounceHeight = 2f;

    private NavMeshAgent agent;
    private Animator anim;
    private float jumpTimer;
    private bool isGrounded = true;
    private float originalY;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (visualModel != null)
        {
            originalY = visualModel.localPosition.y;
        }

        jumpTimer = jumpInterval;
    }

    void Update()
    {
        // El temporizador del ritmo de salto
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0f)
        {
            TriggerJump();
            jumpTimer = jumpInterval; // Reinicia el reloj del siguiente salto
        }

        HandleVisualBounce();
    }

    void TriggerJump()
    {
        // Si el agente se está moviendo o patrullando, el salto se nota más
        if (anim != null)
        {
            // Puedes disparar un Trigger de tu Animator si tienes animación de salto
            anim.SetTrigger("Jump");
        }

        // Truco: Desactivamos el frenado un milisegundo para simular el impulso
        if (agent != null && agent.isOnNavMesh)
        {
            isGrounded = false;
        }
    }

    void HandleVisualBounce()
    {
        // Simulación matemática de arco usando el valor del temporizador (Función Seno)
        if (visualModel != null)
        {
            float normalizedTime = Mathf.Clamp01(1f - (jumpTimer / jumpInterval));
            // Crea una parábola limpia para el salto visual
            float heightOffset = Mathf.Sin(normalizedTime * Mathf.PI) * bounceHeight;

            Vector3 newPos = visualModel.localPosition;
            newPos.y = originalY + heightOffset;
            visualModel.localPosition = newPos;
        }
    }
}