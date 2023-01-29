using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtiteSmashSound : MonoBehaviour
{
    AudioSource audiosource;
    //public float timer;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        StartCoroutine(SmashSound());
        //time = Time.deltaTime;
    }

    /*void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            timer = 0f;
            audiosource.Play();
        }
    }*/

    public IEnumerator SmashSound()
    {
        yield return new WaitForSeconds(2f);
        audiosource.Play();

        /*timer -= Time.deltaTime;
        if(timer < 0f)
        {
            timer = 0f;
            audiosource.Play();
        }
        else if(timer > 0f)
        {
            audiosource.Stop();
        }*/
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            audiosource.Play();
        }
    }*/
}
