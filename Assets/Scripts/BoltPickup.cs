using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPickup : MonoBehaviour
{
    GameManager GM;
    
    public int value;

    public int soundToPlay;

    public GameObject pickupEffect;

    void awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.cur_Bolt++;
    }

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
        if(other.tag == "Player")
        {
            GameManager.instance.AddBolt(value);
            GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            GM.cur_Bolt--;
            GM.AddPowerupAndLife();
            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
