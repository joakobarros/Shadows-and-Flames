using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour
{
    private EnemyMachine enemyMachine;
    private NavMeshControl navMeshControl;
    public Transform objective;
    [SerializeField] private float speed = 5f; 

    void Start()
    {
        enemyMachine = GetComponent<EnemyMachine>();
        navMeshControl = GetComponent<NavMeshControl>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objective.position, speed * Time.deltaTime);
    }

}
