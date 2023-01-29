using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private Transform respawnPoint;
   [SerializeField] private Transform respawnPoint2;

   void OnTriggerEnter(Collider other)
   {
       player.transform.position = respawnPoint.transform.position;
       player.transform.rotation = respawnPoint.transform.rotation;

       player.transform.position = respawnPoint2.transform.position;
       player.transform.rotation = respawnPoint2.transform.rotation;
   }
}
