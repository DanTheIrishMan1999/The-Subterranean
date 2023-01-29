using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    //public GameObject disableObject;
    public static Eraser instance;
    public GameObject platform;
    //GameManager gameManager;
    //[SerializeField] GameObject gamemanager;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    

    /*void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audiosource.Play();
        }
        else if(other.tag == "Ground")
        {
            audiosource.Play();
        }
    }*/

    /*void Awake()
    {
        gameManager = gamemanager.GetComponent<GameManager>(); 
    }*/

    // Start is called before the first frame update

    void Update()
    {
        StartCoroutine(Substitute());
    }

    /*void Start()
    {
        Invoke("DisableObject", 1);
    }*/

    public IEnumerator Substitute()
    {
        //GameManager.instance.RespawnCo();
        yield return new WaitForSeconds(8f);
        Instantiate(platform, transform.position, Quaternion.Euler(180, 0, 0));
        gameObject.SetActive(false);
    }

    /*public void DisableObject(GameObject disableObject)
    {
        disableObject.SetActive(false);
    }*/

    /*void Update()
    {
        GameManager.RespawnCo();

        RespawnCo Respawn = new RespawnCo();

        if(RespawnCo())
        {
            Instantiate(platform, transform.position, Quaternion.Euler(180, 0, 0));
        }
    }*/
}
