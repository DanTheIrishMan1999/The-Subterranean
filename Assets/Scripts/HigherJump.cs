using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherJump : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;

    public float duration = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider Player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerController stats = Player.GetComponent<PlayerController>(); 
        stats.jumpForce *= multiplier;
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<Collider>().enabled = false;
        Destroy(gameObject);

        yield return new WaitForSeconds(duration);


        stats.jumpForce /= multiplier;
        
    }
}
