using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prestart : MonoBehaviour
{
    private SlidesController slidesController;

    void Start()
    {
        slidesController = GetComponentInParent<SlidesController>();
        slidesController.NextSlide();
    }
}

