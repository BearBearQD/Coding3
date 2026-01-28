using UnityEngine;
using UnityEngine.AI;

public class ScountMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(targetPosition);

    }
}
