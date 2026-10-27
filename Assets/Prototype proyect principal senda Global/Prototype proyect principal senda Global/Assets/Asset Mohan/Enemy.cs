using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public NavMeshAgent navMeshAgent;

    [Header("Puntos de Patrullaje")]
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;

    [Header("Configuración de Visión")]
    public float visionRadius = 8f;          // Distancia máxima a la que puede ver
    [Range(0, 360)]
    public float visionAngle = 90f;          // Ángulo del cono de visión (ej. 90 grados al frente)

    [Header("Configuración de Movimiento")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4.5f;

    void Start()
    {
        // Buscar componentes automáticamente si no están asignados
        if (navMeshAgent == null)
            navMeshAgent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        // Iniciar el patrullaje si hay puntos configurados
        if (patrolPoints.Length > 0)
        {
            MoveToNextPoint();
        }
    }

    void Update()
    {
        if (navMeshAgent == null) return;

        // Comprobar si el jugador está en el campo de visión
        if (CanSeePlayer())
        {
            navMeshAgent.speed = chaseSpeed;
            navMeshAgent.destination = player.position;
            return; // Lo persigue y frena temporalmente el patrullaje
        }

        // Si no lo ve, continúa patrullando a velocidad normal
        navMeshAgent.speed = patrolSpeed;
        PatrolLogic();
    }

    bool CanSeePlayer()
    {
        if (player == null) return false;

        // 1. Verificar la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= visionRadius)
        {
            // 2. Verificar el ángulo (que el jugador esté dentro del cono frontal de visión)
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angleBetweenEnemyAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            // Si el ángulo es menor a la mitad del cono total, significa que está al frente
            if (angleBetweenEnemyAndPlayer < visionAngle / 2f)
            {
                return true;
            }
        }
        return false;
    }

    void PatrolLogic()
    {
        if (patrolPoints.Length == 0) return;

        // Comprobar si llegó al punto de patrulla actual
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance + 0.5f)
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0) return;

        navMeshAgent.destination = patrolPoints[currentPointIndex].position;
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }

    // Dibuja el radio y el cono de visión en la escena de Unity para ayudarte a calibrarlo
    void OnDrawGizmosSelected()
    {
        // Dibuja la esfera del radio total de visión (Amarillo)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        // Calcula las líneas del cono de visión (Rojo)
        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle / 2f, 0) * transform.forward * visionRadius;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle / 2f, 0) * transform.forward * visionRadius;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}