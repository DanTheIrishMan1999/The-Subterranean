using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 1f;
    Vector3 startPos;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = this.transform.position;
        audiosource = GetComponent<AudioSource>();
        //InvokeRepeating("OnTriggerEnter", 0.001f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            audiosource.Play();
        }
        if(other.tag == "Player")
        {
            StartCoroutine(Despawn());
        }
        else if(other.tag == "EndObject")
        {
            StartCoroutine(StopBoulder());
        }
    }

    public IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.5f);
        audiosource.Stop();
        //Instantiate(fractured, transform.position, Quaternion.Euler(180, 0, 0));
        gameObject.SetActive(false);
        this.transform.position = startPos;
    }

    public IEnumerator StopBoulder()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector3.zero;
        audiosource.Stop();
    }
}
