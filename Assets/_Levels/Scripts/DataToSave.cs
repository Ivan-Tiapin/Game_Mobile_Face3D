using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataToSave : MonoBehaviour
{
    //private SaveLoad saveLoad;
    private SlidesController slidesController;
    [HideInInspector] public int thisSlideNumber;
    public int thisOpenedSlideMenu;
    public int forkNumberToLoad;
    public GameObject[] slidesVariants;
    [HideInInspector] public GameObject nextSlideToLoad;
    

    public void ChooseNewSlide()
    {
        slidesController = GetComponentInParent<SlidesController>();
        if (nextSlideToLoad == null) 
        {
            return;
        }
        if (forkNumberToLoad==0)
        {
            nextSlideToLoad = slidesVariants[0];
        }
        else
        {
            int i = slidesController.LoadForkData(forkNumberToLoad);
            Debug.Log(i);
            nextSlideToLoad = slidesVariants[i-1];
        }
    }

}
