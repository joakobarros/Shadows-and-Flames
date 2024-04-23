using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshControl : MonoBehaviour
{
    public Transform objective;
    private NavMeshAgent navMeshAgent;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void NavMeshDestiny(Vector3 destiny)
    {
        navMeshAgent.destination = destiny;
        navMeshAgent.isStopped = false;
    }

     public void NavMeshDestiny2()
    {
       NavMeshDestiny(objective.position);
    }

    public void StopAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public bool DestinyArrived()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
}
