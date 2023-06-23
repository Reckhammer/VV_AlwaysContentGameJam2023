using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapAudioManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip Hit;
    public AudioClip PicTake;

    private void Play(AudioClip clip)
    {
        if (source.isPlaying)
            source.Stop();

        source.clip = clip;
        source.Play();
    }

    public void PlayHit()
    {
        Play(Hit);
    }

    public void PlayPicTake()
    {
        Play(PicTake);
    }
}
