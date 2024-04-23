using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatZoneManager : MonoBehaviour
{
    public GameObject[] Walls;
    public Transform[] spawnPoints;
    public GameObject enemy;
    private GameObject me;
    private bool combatZoneActive = false;
    [SerializeField] private bool enemyAlive;
    [SerializeField] private int enemyCant;
    [SerializeField] private int roundNum = 0;
    [SerializeField] private int roundTotal = 3; 

    private void Start() 
    {
        me = this.gameObject;
    }

    void Update()
    {
        enemyAlive = GameObject.FindGameObjectWithTag("EnemyCZ");
        
        if(roundNum < roundTotal && combatZoneActive && !enemyAlive)
        {
            enemyCant = Random.Range(2, 4);
            SpawnEnemies(enemyCant);
        }
        
        if (!combatZoneActive && roundNum == roundTotal && enemyAlive)
        {
            WallsActive(false);
            //Debug.Log("ganaste capo");
            //cambio camara
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //cambio de camara
            me.GetComponent<BoxCollider>().enabled = false;
            WallsActive(true);
            enemyCant = Random.Range(2, 4);
            SpawnEnemies(enemyCant);
            combatZoneActive = true;
            PointsSystem.Instance.ActiveComboMarker(true);
        }  
    }

    private void WallsActive(bool active)
    {
        for (int i = 0; i < Walls.Length; i++)
        {
            Walls[i].SetActive(active);
        }   
    }

    private void SpawnEnemies(int cant)
    {
        for (int e = 0; e < cant; e++)
        {
            int ranSpawn = Random.Range(0, spawnPoints.Length - 1);
            Instantiate(enemy, spawnPoints[ranSpawn].position, Quaternion.identity);
        }

        roundNum++;

        if (roundNum == roundTotal)
        {
            combatZoneActive = false;
        }
        Debug.Log("ronda" + roundNum);
    } 
    
}
