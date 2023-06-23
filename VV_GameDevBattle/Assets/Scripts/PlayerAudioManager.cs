using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource source;
    
    public AudioClip BatSwing;
    public AudioClip PicTaken;
    
    private void Play(AudioClip clip)
    {
        if (source.isPlaying)
            source.Stop();

        source.clip = clip;
        source.Play();
    }

    public void PlayBatSwing()
    {
        Play(BatSwing);
    }

    public void PlayPicTaken()
    {
        Play(PicTaken);
    }
}
