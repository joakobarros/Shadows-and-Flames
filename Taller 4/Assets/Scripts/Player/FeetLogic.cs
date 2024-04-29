using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetLogic : MonoBehaviour
{
   public PlayerController playerController;

   private void OnTriggerStay(Collider other) 
   {
        playerController.jumping = true;
   }

   private void OnTriggerExit(Collider other) 
   {
        playerController.jumping = false; 
   }
}
