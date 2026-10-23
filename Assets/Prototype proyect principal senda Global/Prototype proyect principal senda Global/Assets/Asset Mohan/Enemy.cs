using UnityEngine;
using UnityEngine.AI; // Required for NavMeshAgent

public class Enemy : MonoBehaviour
{

    [Header("Movement & Vision")]
    public float speed = 25f;
    public Transform player;
    public float visionRadius = 50f;

    [Header("Patrol Route")]
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;

    [Header("Idle Wait Settings")]
    public float waitTime = 3f;
    private float waitTimer;
    private bool isWaiting = false;

    [Header("Entrega de Bocadillos & Transición")]
    public Transform puntoSeguroOrilla; // Reaparición si te atrapa sin los 4 bocadillos
    public GameObject panelNegroUI;     // Pantalla a negro
    public string nombreNivel2 = "Nivel2_Amazonas";
    private bool entregado = false;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.speed = speed;
            agent.angularSpeed = 120f;
        }

        MoveToNextPoint();
    }

    void Update()
    {
        if (player == null || agent == null || entregado) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 1. DETECCIÓN DEL JUGADOR
        if (distanceToPlayer <= visionRadius)
        {
            PlayerInventory inventario = player.GetComponent<PlayerInventory>();

            // CASO A: YA TIENE LOS 4 BOCADILLOS -> Se calma y activa el viaje
            if (inventario != null && inventario.SandwichCount >= 4)
            {
                CalmarMohanYViajar();
                return;
            }

            // CASO B: NO TIENE LOS 4 BOCADILLOS -> Lo persigue
            isWaiting = false;
            agent.SetDestination(player.position);

            if (anim != null) anim.Play("Run");
        }
        else
        {
            // STATE: PATROL
            HandlePatrolLogic();
        }
    }

    void HandlePatrolLogic()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting)
        {
            isWaiting = true;
            waitTimer = waitTime;

            if (anim != null) anim.Play("Idle");
        }

        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;

            // CORREGIDO: Ahora sí espera hasta llegar a 0
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
        if (anim != null) anim.Play("Walk");

        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }

    // SI TE TOCA SINO TIENES LOS BOCADILLOS
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !entregado)
        {
         PlayerInventory inventario = other.GetComponent<PlayerInventory>();

            if (inventario == null || inventario.SandwichCount < 4)
            {
                // Te regresa a la orilla
                other.transform.position = puntoSeguroOrilla.position;
                agent.ResetPath();
                MoveToNextPoint();
            }
        }
    }

    // LÓGICA DE DETENCIÓN Y CAMBIO DE NIVEL
    void CalmarMohanYViajar()
    {
        entregado = true;
        agent.isStopped = true; // Detiene el NavMeshAgent por completo
        if (anim != null) anim.Play("Idle");

        Invoke("ActivarPantallaNegra", 1.5f);
    }

    void ActivarPantallaNegra()
    {
        if (panelNegroUI != null) panelNegroUI.SetActive(true);
        Invoke("CargarNivel2", 2.0f);
    }

    void LoadLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreNivel2);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, Vector3.one);
        Gizmos.DrawWireSphere(Vector3.zero, visionRadius);
        Gizmos.matrix = oldMatrix;
    }
}