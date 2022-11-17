using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    public int lastChoice;
    public int currentScene;
    public int currentSlide;
    public int sound;
    public int vibration;
    public int openedLevel;
    public int fork1,fork2,fork3;

    public void SaveGame()
    {
        SaveSystem.SaveProgress(this);
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/player.progress"))
        {
            PlayerProgress data = SaveSystem.LoadProgress();
            lastChoice = data.lastChoice;
            currentScene = data.currentScene;
            currentSlide = data.currentSlide;
            sound = data.sound;
            vibration = data.vibration;
            openedLevel = data.openedLevel;
            fork1 = data.fork1;
            fork2 = data.fork2;
            fork3 = data.fork3;
        }
        else
        {
            lastChoice = 0;
            currentScene = 1;
            currentSlide = 0;
            openedLevel = 1;
        }

    }
}
