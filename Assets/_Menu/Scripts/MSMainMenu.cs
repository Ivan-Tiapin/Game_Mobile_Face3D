using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MSMainMenu : MonoBehaviour
{

    public SaveLoad saveLoad;
    [SerializeField] private int currentScene, currentSlide, sound,vibration,openedLevel;




    private void Start()
    {

        saveLoad.LoadGame();
        sound = saveLoad.sound;
        AudioListener.volume = sound;
        vibration = saveLoad.vibration;

        //Vibration.doesVibrate = vibration;
        currentScene = saveLoad.currentScene;
        currentSlide = saveLoad.currentSlide;
        openedLevel = saveLoad.openedLevel;

        if(currentScene == 0)
        {
            saveLoad.currentScene = 1;
            saveLoad.currentSlide = 0;
            saveLoad.openedLevel = 1;
            saveLoad.SaveGame();
        }

    }
    public void StartButton()
    {
        SceneManager.LoadScene(currentScene);
    }

}
