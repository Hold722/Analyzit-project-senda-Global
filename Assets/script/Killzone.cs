using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    public NavMeshAgent Cube;
    public Transform PlayerArmature;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cube.SetDestination(PlayerArmature.position);
    }

}
