using UnityEngine;
using UnityEngine.AI;

public class SimplePatrol : MonoBehaviour
{
    public Transform[] waypoints;//Estrucutura los puntos de ruta para el NPC, se pueden agregar o quitar puntos en el inspector de Unity

    private NavMeshAgent agent;//Le dara en control al NPC para moverse por el escenario, se le asigna el componente NavMeshAgent del objeto en el que esta este script
    private int currentWaypoint = 0;//Puntos de Ruta que le Indicara al NPC a donde ir, se inicia en 0 para que el NPC empiece en el primer punto de ruta

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination =
        waypoints[currentWaypoint].position;
    }

    void Update()
    {
        if (!agent.pathPending &&
           agent.remainingDistance < 0.5f)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }

            agent.destination =
            waypoints[currentWaypoint].position;
        }
    }
}