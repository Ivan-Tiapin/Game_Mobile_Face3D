using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideChooser : MonoBehaviour
{
    [SerializeField] private SlideExecutor[] collectorArray;
    [SerializeField] private List<GameObject> slides;
    private SlidesController slidesController;
    public int forkToLoad;
    public bool additionalCheck;
    void Start()
    {
        slidesController = GetComponentInParent<SlidesController>();
        slides = new List<GameObject>();
        collectorArray = GetComponentsInChildren<SlideExecutor>(true);
        foreach (var data in collectorArray)
        {
            slides.Add(data.gameObject);
        }

        if (forkToLoad == 0 || slides.Count == 1)
        {
            slides[0].SetActive(true);
        }
        else
        {
            int i = slidesController.LoadForkData(forkToLoad);
            Debug.Log(i);
            if (additionalCheck&& forkToLoad==2)
            {
                if (i == 3)
                {
                    i = slidesController.LoadForkData(1);
                }
                else
                {
                    i = 3;
                }
            }
            if (additionalCheck && forkToLoad == 1)
            {
                if (slidesController.LoadForkData(2) == 3)
                {
                    i = 3;
                }
                else
                {
                    i = slidesController.LoadForkData(forkToLoad);
                }

            }
            Debug.Log("i" + i);
            slides[i - 1].SetActive(true);
        }
    }

}
