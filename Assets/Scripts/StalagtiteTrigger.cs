using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtiteTrigger : MonoBehaviour
{
    public GameObject Stalagtite;
    public GameObject Trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Stalagtite.SetActive(true);
            Trigger.SetActive(false);
        }
    }
}
