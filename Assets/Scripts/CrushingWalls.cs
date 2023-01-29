using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingWalls : MonoBehaviour
{
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CrushingWall")
        {
            audiosource.Play();
        }
    }
}
