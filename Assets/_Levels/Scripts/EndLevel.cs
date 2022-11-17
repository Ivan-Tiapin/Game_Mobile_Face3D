using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private SlidesController slidesController;
    void Start()
    {
        slidesController = GetComponentInParent<SlidesController>();
        slidesController.NextSlide();
    }

}
