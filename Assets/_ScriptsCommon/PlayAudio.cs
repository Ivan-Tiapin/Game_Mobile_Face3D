using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayAudio : MonoBehaviour
{
    private AudioSource player;

    void Start() 
    {
    if (GetComponent<AudioSource>() != null)
        {
            player = GetComponent<AudioSource>();
        }
    }
    public void PlayAudioClip()
    {
        player.Play();
    }
}
