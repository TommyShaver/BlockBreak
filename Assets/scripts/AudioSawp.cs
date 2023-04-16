using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSawp : MonoBehaviour
{

    public AudioClip newTrack;
    public AudioClip winTrack;

    private BounceBall ballBounceScript;
    bool playSoundOnce;

    private void Awake()
    {
        ballBounceScript = GameObject.Find("ball").GetComponent<BounceBall>();
    }
    private void Start()
    {
        playSoundOnce = false;
    }
    private void Update()
    {
       if(!playSoundOnce && ballBounceScript._LoserGameOver)
        {
            AudioManager.instance.SwapTrack(newTrack);
            playSoundOnce = true;
        }
        if (!playSoundOnce && ballBounceScript._WinnerGameOver)
        {
            AudioManager.instance.SwapTrack(winTrack);
            playSoundOnce = true;
        }
    }

    
}
