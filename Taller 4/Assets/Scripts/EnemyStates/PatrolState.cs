using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    private EnemyMachine enemyMachine;
    public Transform [] wayPoints;
    private NavMeshControl navMeshControl;
    private int nextWayPoint = 0;

    void Start()
    {
        enemyMachine = GetComponent<EnemyMachine>();
        navMeshControl = GetComponent<NavMeshControl>();
    }

    void Update()
    {
        if (navMeshControl.DestinyArrived())
        {
            nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
            NewDestination(); 
        }
    }

    private void OnEnable() 
    {
        NewDestination();    
    }

    private void NewDestination()
    {
        navMeshControl.NavMeshDestiny(wayPoints[nextWayPoint].position); 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyMachine.ActivateState(enemyMachine.ChaseState);
        }    
    }
}
