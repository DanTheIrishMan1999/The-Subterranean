using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runfast : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;

    public int soundToPlay;

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

        AudioManager.instance.PlaySFX(soundToPlay);

        PlayerController stats = Player.GetComponent<PlayerController>();
        stats.moveSpeed *= multiplier;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);


        stats.moveSpeed /= multiplier;
        Destroy(gameObject);
    }
}

