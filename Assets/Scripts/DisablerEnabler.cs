using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablerEnabler : MonoBehaviour
{
    //public GameObject MovingPlatform;
    //public MovingPlatformScript moving;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MovingPlatformScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Enabler());
    }

    public IEnumerator Enabler()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<MovingPlatformScript>().enabled = true;
    }
}
