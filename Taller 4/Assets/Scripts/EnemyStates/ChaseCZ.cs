using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCZ : MonoBehaviour
{
    private NavMeshControl navMeshControl;
    private Transform objective;
    [SerializeField] private float speed = 3f; 

    void Start()
    {
        navMeshControl = GetComponent<NavMeshControl>();
    }
    void Update()
    {
        objective = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position, objective.position, speed * Time.deltaTime);
    }

}
