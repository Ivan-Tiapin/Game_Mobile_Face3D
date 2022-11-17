using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BGPlay : MonoBehaviour
{
    //reduce lags on start of the game
    public VideoPlayer videoPlayer;
    void Awake()
    {
        videoPlayer.Play();
    }

}
