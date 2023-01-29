using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    public static Fracture instance;
    public GameObject fractured;
    AudioSource audiosource;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Dropdown());
            audiosource.Play();
        }
    }

    public IEnumerator Dropdown()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(fractured, transform.position, Quaternion.Euler(180, 0, 0));
        gameObject.SetActive(false);
    }
}
