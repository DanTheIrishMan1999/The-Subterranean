using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    public static Replacer instance;
    public GameObject stalagtite;
    //AudioSource audiosource;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //audiosource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update

    void Update()
    {
        StartCoroutine(SubstituteStalagtite());
    }

    /*void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audiosource.Play();
            StartCoroutine(SubstituteStalagtite());
        }
        else if(other.tag == "Ground")
        {
            audiosource.Play();
            StartCoroutine(SubstituteStalagtite());
        }
    }*/

    //WaitForSeconds wTime1 = new WaitForSeconds(1.5f);
    //WaitForSeconds wTime2 = new WaitForSeconds(8f);

    public IEnumerator SubstituteStalagtite()
    {
        //yield return wTime1;
        //yield return new WaitForSeconds(1.5f);
        //audiosource.Play();
        //yield return wTime2;
        yield return new WaitForSeconds(8f);
        Instantiate(stalagtite, transform.position, Quaternion.Euler(90, 0, 0));
        stalagtite.SetActive(true);
        gameObject.SetActive(false);
    }
}
