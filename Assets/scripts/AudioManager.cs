using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip defaultAudioClip;

    private AudioSource mainTheme, losingTheme;
    private bool isPlayingMainTheme;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        mainTheme = gameObject.AddComponent<AudioSource>();
        losingTheme = gameObject.AddComponent<AudioSource>();
        isPlayingMainTheme = true;
        SwapTrack(defaultAudioClip);
        mainTheme.volume = 0.5f;
        mainTheme.loop = true;
    }
     public void SwapTrack(AudioClip newClip)
    {
        if(isPlayingMainTheme)
        {
            mainTheme.clip = newClip;
            mainTheme.Play();
            losingTheme.Stop(); 
        }
        else
        {
            losingTheme.clip = newClip;
            losingTheme.Play();
            mainTheme.Stop();
        }
        isPlayingMainTheme = !isPlayingMainTheme;
        
    }
    public void ReutrntoDefault()
    {
        SwapTrack(defaultAudioClip);
    }
   
}
