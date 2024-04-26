using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//for audio management

public class Audio : MonoBehaviour
{
  
    public enum AudioCategory
    //enums are named constants
    {
        SoundFX,
        Ambience,
        MasterVolume,
        Music
    }
    public AudioMixer audioMixer;
    //reference an audio mixer class
    public AudioCategory audioCategory;
    //setting to public so that i can configure category
    //from inspector window
    public void setVolume(float volume)
    {
        audioMixer.SetFloat(audioCategory.ToString(), volume);
        //typecast enum to string
        //pass in volume to relevant exposed parameter
    }
}