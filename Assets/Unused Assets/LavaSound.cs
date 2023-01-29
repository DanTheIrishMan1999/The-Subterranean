using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSound : MonoBehaviour
{

    public int soundToPlay;
    
    private void PlaySoundEffect()
    {
        AudioManager.instance.PlaySFX(soundToPlay);
    }
}
