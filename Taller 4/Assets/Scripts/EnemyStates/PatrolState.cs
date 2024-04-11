using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    private EnemyMachine enemyMachine;
    public Transform [] wayPoints;
    private NavMeshControl navMeshControl;
    private int nextWayPoint;

    void Start()
    {
        enemyMachine = GetComponent<EnemyMachine>();
        navMeshControl = GetComponent<NavMeshControl>();
    }

    // Update is called once per frame
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
