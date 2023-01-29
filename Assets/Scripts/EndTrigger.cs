using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class EndTrigger : MonoBehaviour
{
    public Animator anim; // fetches space for the animator in the inspector to be linked to this script
    
    public GameManager gameManager; // fetches space for the gamemanager in the inspector to be linked to this script

    /*private void OnCollisionEnter(Collision collision)
    {
        End.Invoke();
    }*/

    private void OnTriggerEnter(Collider other) // entering collider as player will trigger the animation and activate the CompleteLevelUI function in the gamemanager script
    { 
        if(other.tag == "Player")
        {
            anim.SetTrigger("Hit");

            StartCoroutine(GameManager.instance.LevelEndCo());

            //gameManager.CompleteLevelUI();
        }
        
    }
}
