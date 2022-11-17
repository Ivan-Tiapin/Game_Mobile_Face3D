using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProgress 
{
    public int lastChoice;
    public int openedLevel;
    public int currentScene;
    public int currentSlide;
    public int sound;
    public int vibration;
    public int fork1, fork2, fork3;

    public PlayerProgress(SaveLoad saveLoad)

    {
        lastChoice = saveLoad.lastChoice;
        currentScene = saveLoad.currentScene;
        currentSlide = saveLoad.currentSlide;
        sound = saveLoad.sound;
        vibration = saveLoad.vibration;
        openedLevel = saveLoad.openedLevel;
        fork1 = saveLoad.fork1;
        fork2 = saveLoad.fork2;
        fork3 = saveLoad.fork3;
    }
}
