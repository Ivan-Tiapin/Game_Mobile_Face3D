using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideExecutor : MonoBehaviour
{
    private SlidesController slidesController;
    private FadeController fadeController;
    public GameObject[] events;
    private int evenCounter;
    //private SaveLoad saveLoad;
    //public int lastChoice;
    //private ForksSaver forksSaver;
    //public int forkToLoad;

    private void Start()
    {
        evenCounter = 0;
        //lastChoice = 0;
        //if (GetComponentInChildren<ForksSaver>() != null)
        //{ forksSaver = GetComponentInChildren<ForksSaver>(); }

        
        slidesController = GetComponentInParent<SlidesController>();
        fadeController = GetComponentInChildren<FadeController>();
    }

    public void EventLauncher()
    {

        if (events.Length == 0)
        {
            EndSlide(); }
        else
        {
            if (evenCounter == 0)
            {

                events[evenCounter].SetActive(true);

            }
            else
            {
                if (evenCounter < events.Length)
                {
                    events[evenCounter - 1].SetActive(false);
                    events[evenCounter].SetActive(true);
                }
                else
                {
                    events[evenCounter - 1].SetActive(false);

                    EndSlide();
                    return;
                }
            }
            evenCounter++;
        }
    }

    public void EndSlide()
    {
        //if (nextSlide1 != null)
        //{
        //    if (nextSlide2 != null)
        //    {
        //        if (forksSaver!=null)
        //        {
        //            lastChoice = forksSaver.LoadFork(forkToLoad);
        //        }
        //        if (lastChoice < 2)
        //        {
        //            slidesController.Choice(nextSlide1);
        //        }
        //        else if (lastChoice == 2)
        //        {
        //            slidesController.Choice(nextSlide2);
        //        }
        //        else if (lastChoice == 3)
        //        {
        //            slidesController.Choice(nextSlide3);

        //        }

        //    }
        //    else
        //    {
        //        slidesController.Choice(nextSlide1);
        //    }
        //}
        //nextSlide1 = null;
        //nextSlide2 = null;
        //nextSlide3 = null;

        fadeController.FadeOutTrigger();

    }
}
