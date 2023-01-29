using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;

    private void OnTriggerEnter(Collider other)
    {
        isFalling = true;
        other.transform.parent = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFalling)
        {
            downSpeed += Time.deltaTime/10;
            transform.position = new Vector3(transform.position.x,
            transform.position.y-downSpeed,
            transform.position.z);
        }
    }

    /*private void OnTriggerEnter(Collider other) // when entering the platform, the platform becomes a parent to the player object
    {
        other.transform.parent = transform;
    }*/

    private void OnTriggerExit(Collider other) // when exiting the platform, the player is no longer a child of the platform
    {
        other.transform.parent = null;
    }
}
