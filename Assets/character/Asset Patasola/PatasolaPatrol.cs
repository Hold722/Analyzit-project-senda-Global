using UnityEngine;
using UnityEngine.AI;

public class PatasolaPatrol : MonoBehaviour
{
    [Header("Movement & Vision")]
    public float speed = 15f;
    public Transform player; // ¡OJO! Hay que arrastrar el jugador aquí en el Inspector
    public float visionRadius = 35f;

    [Header("Patrol Route")]
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;

    [Header("Idle Wait Settings")]
    public float waitTime = 3f;
    private float waitTimer;
    private bool isWaiting = false;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (agent != null)
        {
            agent.speed = speed;
        }

        MoveToNextPoint();
    }

    void Update()
    {
        if (agent == null) return;

        // 1. Enviamos la velocidad al Animator para el Blend Tree (Salto quieta vs Salto moviéndose)
        if (anim != null)
        {
            float currentSpeed = agent.velocity.magnitude;
            anim.SetFloat("Speed", currentSpeed);
        }

        // 2. CONTROL DE SEGURIDAD: Si no has arrastrado al jugador, solo patrulla y no se bugea
        if (player == null)
        {
            HandlePatrol();
            return;
        }

        // 3. Calcular distancia real al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 4. ¿EL JUGADOR ENTRÓ EN EL RANGO?
        if (distanceToPlayer <= visionRadius)
        {
            // ESTADO: CHASE (Persecución directa)
            isWaiting = false;
            agent.SetDestination(player.position);
        }
        else
        {
            // ESTADO: PATROL (Seguir la ruta de waypoints)
            HandlePatrol();
        }
    }

    void HandlePatrol()
    {
        // Si llegó al waypoint y no está esperando todavía
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting)
        {
            isWaiting = true;
            waitTimer = waitTime;
        }

        // Cuenta regresiva del tiempo de espera en el punto
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                isWaiting = false;
                MoveToNextPoint();
            }
        }
    }

    void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, Vector3.one);
        Gizmos.DrawWireSphere(Vector3.zero, visionRadius);
        Gizmos.matrix = oldMatrix;
    }
}