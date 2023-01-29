using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject cpOn, cpOff;

    public int soundToPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.SetSpawnPoint(transform.position);

        Checkpoint[] allCP = FindObjectsOfType<Checkpoint>();
        for(int i = 0; i < allCP.Length; i++)
        {
            allCP[i].cpOff.SetActive(true);
            allCP[i].cpOn.SetActive(false);

            if(other.tag == "Player")
            {
                AudioManager.instance.PlaySFX(soundToPlay); // allows the audio clip to play once
            }
        }

        cpOff.SetActive(false);
        cpOn.SetActive(true);
    }
}

