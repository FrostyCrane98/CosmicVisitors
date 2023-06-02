using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip _clip)
    {
        source.clip = _clip;
        source.Play();
    }

    public void Pause()
    {
        source.Pause();
    }

    public void Resume()
    {
        source.UnPause();
    }

    public void Stop(AudioClip _clip)
    {
        source.clip = _clip;
        source.Stop();
    }

    public void ToggleLoop(bool _toggle)
    {
        if (_toggle == true)
        {
            source.loop = true;
        }
        else
        {
            source.loop = false;
        }
    }

}
