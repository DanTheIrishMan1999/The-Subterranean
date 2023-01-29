//------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//------------------------------
public class ProxyDamage : MonoBehaviour
{
    //public float radius = 1;
    //------------------------------

    //------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // When entering player's collider, this causes damage to the player via the hurt function in the health manager script
        {
            HealthManager.instance.Hurt();
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider other in colliders)
        {
            if (other.tag == "Player") // When entering player's collider, this causes damage to the player via the hurt function in the health manager script
            {
                HealthManager.instance.Hurt();
            }
        }
    }*/
    //------------------------------
}
//-----------------------------