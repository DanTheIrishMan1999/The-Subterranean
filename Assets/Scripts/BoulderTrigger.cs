using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{
    public GameObject Boulder;
    public int soundToPlay;
    //public GameObject Trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TheBoulder());
        }
    }

    public IEnumerator TheBoulder()
    {
        AudioManager.instance.PlaySFX(soundToPlay);
        yield return new WaitForSeconds(3f);
        Boulder.SetActive(true);
        //Trigger.SetActive(false);
    }
}
