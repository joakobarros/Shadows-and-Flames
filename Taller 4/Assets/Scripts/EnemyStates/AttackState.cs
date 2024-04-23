using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    private EnemyMachine enemyMachine;
    private NavMeshControl navMeshControl;
    private Vector3 objective;
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float jumpForce = 5f; 
     void Awake()
    {
        enemyMachine = GetComponent<EnemyMachine>();
        navMeshControl = GetComponent<NavMeshControl>();
        objective = new Vector3(navMeshControl.objective.position.x, navMeshControl.objective.position.y + jumpForce, navMeshControl.objective.position.z);
    }

    void Start()
    {
       Attack();   
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, objective, speed * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        enemyMachine.ActivateState(enemyMachine.ChaseState);
    }

}
