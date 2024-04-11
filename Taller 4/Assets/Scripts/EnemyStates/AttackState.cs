using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    private EnemyMachine enemyMachine;
    private NavMeshControl navMeshControl;
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 5f; 
     void Awake()
    {
        enemyMachine = GetComponent<EnemyMachine>();
        navMeshControl = GetComponent<NavMeshControl>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Attack();   
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(5f);
        enemyMachine.ActivateState(enemyMachine.ChaseState);
    }
}
