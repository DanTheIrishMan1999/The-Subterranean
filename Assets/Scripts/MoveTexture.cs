using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // speed at which the texture scrolls at
    Renderer rend; // reference to the renderer of the object
    AudioSource audiosource;

    void Start()
    {
       rend = GetComponent<Renderer>(); // fetches the renderer component for any object script is attached to
       audiosource = GetComponent<AudioSource>(); // Fetches the audiosource component 
       InvokeRepeating("PlaySound", 0.001f, 4.5f);
    }

    void PlaySound()
    {
        audiosource.Play();
    }

    // gets the texture to move over time at allotted speed on the Y axis
    void Update()
    {
        float moveThis = Time.time * scrollSpeed; 
        rend.material.SetTextureOffset("_MainTex", new 
        Vector2(0, moveThis));
    }
}
