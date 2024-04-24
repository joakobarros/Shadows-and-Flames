using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLIfe : MonoBehaviour
{
    [SerializeField] private int lifeMax;
    [SerializeField] private int lifeNow;
    [SerializeField] private int points;
    [SerializeField] private float damage;
    private GameObject me;

    private void Start()
    {
        lifeNow = lifeMax;
        me = this.gameObject;
    }

    private void Update()
    {
        if (lifeNow <= 0)
        {
            Destroy(me);
        }
    }

    public void OnHit(int damagePlayer) 
    {
        lifeNow = lifeNow - damagePlayer;
        Debug.Log(lifeNow);   
    }

    private void OnDestroy() 
    {
        PointsSystem.Instance.CountPoints(points);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().OnHit(damage);
        }    
    }
}
