using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachine : MonoBehaviour
{
    public MonoBehaviour patrolState;
    public MonoBehaviour AttackState;
    public MonoBehaviour ChaseState;
    public MonoBehaviour initialState;
    private MonoBehaviour actualState;

    void Start()
    {
        ActivateState(initialState);
    }

    public void ActivateState(MonoBehaviour newState)
    {
        if (actualState != null)
        {
            actualState.enabled = false;
        } 
        actualState = newState;
        actualState.enabled = true;
    }
}
