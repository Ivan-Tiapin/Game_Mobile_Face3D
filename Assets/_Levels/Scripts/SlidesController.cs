using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SlidesController : MonoBehaviour
{
    public SaveLoad saveLoad;
    public int currentScene;
    public int currentSlide;
    [SerializeField] private int fork1, fork2, fork3;
    private int[] forks;
    public SlideChooser[] slideChoosers;
    public List<GameObject> slides;

    void Start()
    {
        //collecting all slides
        slides = new List<GameObject>();
        slideChoosers = GetComponentsInChildren<SlideChooser>(true);
        foreach (var slide in slideChoosers)
        {
            slides.Add(slide.gameObject);
        }
        
        //load data
        saveLoad.LoadGame();
        currentScene = saveLoad.currentScene;
        currentSlide = saveLoad.currentSlide;
        fork1 = saveLoad.fork1;
        fork2 = saveLoad.fork2;
        fork3 = saveLoad.fork3;
        forks = new int[] { fork1, fork2, fork3 };
        //test starts
        //forks[0] = 1;

        //test ends

        //load slides
        slides[currentSlide].SetActive(true);

    }
    public void NextSlide()
    {

        slides[currentSlide].SetActive(false);
        currentSlide = currentSlide + 1;
        if (currentSlide < slides.Count) //next slide
        {
            saveLoad.currentSlide = currentSlide;
            saveLoad.SaveGame();
            slides[currentSlide].SetActive(true);
        }
        else // next scene
        {
            int nextSceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneNumber < SceneManager.sceneCountInBuildSettings)
            {
                saveLoad.currentSlide = 0;
                saveLoad.currentScene = nextSceneNumber;
                saveLoad.SaveGame();
                SceneManager.LoadScene(nextSceneNumber);
            }
            else
            {
                Debug.Log("End");
                SceneManager.LoadScene(0);
            }
        }
        //DataToSave dataToSave = slides[slideCounter].GetComponent<DataToSave>();//get next slide from current slide
        //dataToSave.ChooseNewSlide();
        //GameObject nextSlide = dataToSave.nextSlideToLoad;
        //tempSlideCounter = slideCounter;

        //if (nextSlide == null) //next scene
        //{
        //    slides[slideCounter].SetActive(false);
        //    saveLoad.currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        //    saveLoad.currentSlide = 0;
        //    saveLoad.openedLevel = 1;
        //    saveLoad.SaveGame();

        //}
        //else
        //{
        //    for (int i = 0; i < slides./*Length*/Count; i++)
        //    {
        //        if (slides[i] == nextSlide)
        //        {
        //            slideCounter = i;

        //            break;
        //        }
        //    }
        //    dataToSave = slides[slideCounter].GetComponent<DataToSave>();//new slide
        //    saveLoad.currentScene = SceneManager.GetActiveScene().buildIndex;
        //    saveLoad.currentSlide = dataToSave.thisSlideNumber;
        //    saveLoad.openedLevel = dataToSave.thisOpenedSlideMenu;
        //    saveLoad.SaveGame();
        //    slides[tempSlideCounter].SetActive(false);
        //    slides[slideCounter].SetActive(true);

        ////}

    }

    //fork control part
    public void SaveForkData(int forkNumberNeeded, int forkDataToSave)
    {
        Debug.Log("2");
        if (forkNumberNeeded > 0)
        {
            forks[forkNumberNeeded - 1] = forkDataToSave;
            ForksSave();
        }
    }

    public int LoadForkData(int forkNumberNeeded)
    {
        return forks[forkNumberNeeded-1];
    }

    public void ForksSave()
    {
        saveLoad.fork1 = forks[0];
        saveLoad.fork2 = forks[1];
        saveLoad.fork3 = forks[2];
        saveLoad.SaveGame();
        forks = new int[] { forks[0], forks[1], forks[2] };
    }
}
