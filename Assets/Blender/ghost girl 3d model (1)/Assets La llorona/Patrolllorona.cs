using UnityEngine;
using UnityEngine.AI;

public class PatrullajeLlorona : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform[] Waypoints; // Puntos del cementerio
    private int indiceActual = 0;
    public float distanciaMinima = 1.5f;

    [Header("== Settings Vision ==")]
    public Transform player;        
    public float radioVision = 10f;  
    public float Pursuitspeed = 6f;
    public float velocitypatrol = 3.5f;

    private bool following = false;

    void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();


        if (player== null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }

        if (Waypoints.Length > 0 && player != null)
        {
            IrAlSiguientePunto();
        }
    }

    void Update()
    {
        if (player == null) return;

       
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

       
        if (distanciaAlJugador <= radioVision)
        {
            // ¡Te vio! Te empieza a perseguir
            following = true;
            agent.speed = Pursuitspeed;
            agent.destination = player.position; 
        }
        else
        {
            
            if (following)
            {
                following = false;
                agent.speed = velocitypatrol;
                IrAlSiguientePunto(); 
            }

          
            if (Waypoints.Length == 0) return;

            if (!agent.pathPending && agent.remainingDistance < distanciaMinima)
            {
                IrAlSiguientePunto();
            }
        }
    }

    void IrAlSiguientePunto()
    {
        if (Waypoints.Length == 0 || following) return;
        agent.destination = Waypoints[indiceActual].position;
        indiceActual = (indiceActual + 1) % Waypoints.Length;
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioVision);
    }
}
