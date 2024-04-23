using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public int damage;

    public void SetDamage(int damageAttack)
    {
        damage = damageAttack;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyLIfe>().OnHit(damage);
            PointsSystem.Instance.HitMarker();
        }

        if (other.gameObject.CompareTag("EnemyCZ"))
        {
            other.GetComponent<EnemyLIfe>().OnHit(damage);
            PointsSystem.Instance.HitMarker();
        }
    }
}
