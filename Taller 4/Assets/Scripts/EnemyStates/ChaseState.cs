using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour
{
    private EnemyMachine enemyMachine;
    private NavMeshControl navMeshControl;

    private void OnEnable() 
    {
        navMeshControl.NavMeshDestiny();    
    }
    void Start()
    {
        enemyMachine = GetComponent<EnemyMachine>();
        navMeshControl = GetComponent<NavMeshControl>();
    }
    void Update()
    {
        if (navMeshControl.DestinyArrived())
        {
            enemyMachine.ActivateState(enemyMachine.AttackState);
        }
    }
}
