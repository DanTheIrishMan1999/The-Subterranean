using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappingSpikeWall : MonoBehaviour
{
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        InvokeRepeating("PlaySound", 0.001f, 3.5f);
        //StartCoroutine(Snapper());
    }

    void PlaySound()
    {
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public IEnumerator Snapper()
    {
        yield return new WaitForSeconds(0.5f);
        audiosource.Play();
    }*/
}
