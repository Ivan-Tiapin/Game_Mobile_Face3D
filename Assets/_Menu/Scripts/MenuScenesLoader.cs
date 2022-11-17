using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScenesLoader : MonoBehaviour
{
    // check which levels have been passed before
    [HideInInspector] public SceneLoader[] scenes;
    [HideInInspector] public SaveLoad saveLoad;
    private int[] forks;
    [HideInInspector] public int currentScene, fork1, fork2, fork3,currentSlide;


    void Start()
    {

        scenes = GetComponentsInChildren<SceneLoader>(true);
        saveLoad.LoadGame();
        currentScene = saveLoad.currentScene;
        currentSlide = saveLoad.currentSlide;
        fork1 = saveLoad.fork1;
        fork2 = saveLoad.fork2;
        fork3 = saveLoad.fork3;
        forks = new int[] { fork1, fork2, fork3 };
        
        
        for (int i = 0; i < currentScene; i++) //currentScene=0 is ManiMenuScene
        {
            scenes[i].LevelButtonsEnable(currentScene, currentSlide, i+1);
        }
    }

    public int LoadForkData (int forkNumberNeeded)
    {
        return forks[forkNumberNeeded-1];
    }


    public void LoadLevel(int sceneToLoad, int newCurrentSlide)
    {
        saveLoad.currentScene = sceneToLoad;
        saveLoad.currentSlide = newCurrentSlide;
        saveLoad.SaveGame();
        SceneManager.LoadScene(sceneToLoad);
    }
}
