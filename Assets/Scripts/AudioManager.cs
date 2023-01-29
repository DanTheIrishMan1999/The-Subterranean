using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // creates the public instance for the audiomanager script

    public AudioSource[] music; // space for music audiosource to be plugged in, in the inspector to allow for volume alteration
    public AudioSource[] sfx; // space for sfx audiosource to be plugged in, in the inspector to allow for volume alteration
    public AudioSource[] voice; // space for voice clip audiosource to be plugged in, in the inspector to allow for volume alteration                                          
    
    public int levelMusicToPlay; // changable integer field in inspector for levelmusictoplay

    public AudioMixerGroup musicMixer, sfxMixer, voiceMixer; // the audio groups for the audiomixer to pull from

    //private int currentTrack;

    private void Awake() // instantiates as soon as the scene boots up
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic(levelMusicToPlay); // plays the music entered as levelmusictoplay
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.M))
        {
            currentTrack++;
            PlayMusic(currentTrack);
        } */
    }

    public void PlayMusic(int musicToPlay) // function that allows for the music to be played and stopped
    {
        for(int i = 0; i < music.Length; i++)
        {
            music[i].Stop();
        }

        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxToPlay) // function that allows for the sound effects to be played
    {
        sfx[sfxToPlay].Play();
    }

    public void PlayVoice(int voiceToPlay) // function that allows for the voice clips to be played
    {
        voice[voiceToPlay].Play();
    }

    public void StopVoice(int voiceToPlay) // function that allows for the voice clips to be stopped
    {
        voice[voiceToPlay].Stop();
    }

    /*public void StopMusic(int MusicToPlay)
    {
        music[musicToPlay].Stop();
    }*/

    public void SetMusicLevel() // links to the audiomixer controling the volume of the music and links it to the slider in the UI
    {
        musicMixer.audioMixer.SetFloat("MusicVol", UIManager.instance.musicVolSlider.value);
    }

    public void SetSFXLevel() // links to the audiomixer controling the volume of the sound effects and links it to the slider in the UI
    {
        sfxMixer.audioMixer.SetFloat("SfxVol", UIManager.instance.sfxVolSlider.value);
    }

    public void SetVoiceLevel() // links to the audiomixer controling the volume of the voice clips and links it to the slider in the UI
    {
        voiceMixer.audioMixer.SetFloat("VoiceVol", UIManager.instance.voiceVolSlider.value);
    }
}
