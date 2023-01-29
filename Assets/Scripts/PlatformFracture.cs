using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFracture : MonoBehaviour
{
    public static PlatformFracture instance;
    
    public GameObject fractured;

    private void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Collapse());
        }
    }

    public IEnumerator Collapse()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(fractured, transform.position, Quaternion.Euler(180, 0, 0));
        gameObject.SetActive(false);
    }
}
