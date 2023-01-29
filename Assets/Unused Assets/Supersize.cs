using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supersize : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider Player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        Player.transform.localScale *= multiplier;

        Destroy(gameObject);
    }
}
