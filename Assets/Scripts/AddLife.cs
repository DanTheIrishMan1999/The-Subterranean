using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour
{
    private LifeManager lifeSystem;

    public int soundToPlay;

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        lifeSystem = FindObjectOfType<LifeManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            lifeSystem.GiveLife();
            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
