using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button[] levels;
    private LevelLoader temp;


    public void LevelButtonsEnable(int currentScene, int currentSlide, int thisSceneNumber)
    {
        levels = GetComponentsInChildren<Button>(true);
        Debug.Log("Levelfunc"+thisSceneNumber);
        if (thisSceneNumber < currentScene)
        {
            for (int i =0; i< levels.Length; i++)
            {
                temp = levels[i].gameObject.GetComponent<LevelLoader>();
                temp.currentSlide = i;
                temp.thisLevelScene = thisSceneNumber;
                levels[i].interactable = true;

            }
        }
        if (thisSceneNumber == currentScene)
        {
            Debug.Log(thisSceneNumber);
            Debug.Log(currentScene);
            Debug.Log(currentSlide);
            Debug.Log(levels[0]);
            for (int i = 0; i <= currentSlide; i++)
            {
                temp = levels[i].gameObject.GetComponent<LevelLoader>();
                temp.currentSlide = i;
                temp.thisLevelScene = thisSceneNumber;
                levels[i].interactable = true;
            }
        }
    }


}
