using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    private SlidesController slidesController;
    private SlideExecutor slideExecutor;
    private Animator animator;
    public float fadeInTimeInMls;
    public float fadeOutTimeInMls;





    private void Start()
    {

        if (fadeInTimeInMls == 0) { fadeInTimeInMls = 250; } //default fade = 1 sec
        if(fadeOutTimeInMls == 0) { fadeOutTimeInMls = 250; }
        slidesController = GetComponentInParent<SlidesController>();
        slideExecutor = GetComponentInParent<SlideExecutor>();
        animator = GetComponent<Animator>();

    }
    public void FadeInTrigger()
    {

        animator.speed = 1000/fadeInTimeInMls;           
        animator.SetTrigger("FadeScreen");
    }

    public void FadeOutTrigger()
    {
        animator.speed = 1000/fadeOutTimeInMls;
        animator.SetTrigger("FadeScreen");
    }
    public void StartSlide()
    {
        slideExecutor.EventLauncher();

    }
    
    public void CallNextSlide()
    {
        slidesController.NextSlide();
    }
}
