using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public float radius = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // Forces the respawn function to be called when player enters collider, instantly killing and then respawning the player
        {
            GameManager.instance.Respawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider other in colliders)
        {
            if (other.tag == "Player") // When entering player's collider, this causes damage to the player via the hurt function in the health manager script
            {
                GameManager.instance.Respawn();
            }
        }
    }
}
