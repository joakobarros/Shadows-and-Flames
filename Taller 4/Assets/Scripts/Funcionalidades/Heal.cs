using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float heal;
    private GameObject me;

    private void Start()
    {
        me = this.gameObject;
    }
   private void OnTriggerEnter(Collider other) 
   {
        other.gameObject.GetComponent<PlayerLife>().Healing(heal);
        Destroy(me);
   }
}
