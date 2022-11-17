using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FaceBulbChoice : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ChoiceData choiceData;
    private Animator bulbDisappearAnim;
    private bool showSpoiler;
    [HideInInspector] public bool click = false;
    public Animator textboxSpoilerAnim;
    [HideInInspector] public bool clickable = true;
    public bool tutorial;


    void Start ()
    {
        if (!tutorial)
        {
            click = true;
        }
        bulbDisappearAnim = GetComponent<Animator>();
        choiceData = GetComponentInParent<ChoiceData>();
        if (choiceData.otherButton == null) 
        {
            Debug.Log("No alt");
            PrepareToStart();
        }
    }

    public void PrepareToStart()
    {
        clickable = false;
        choiceData.StartGame();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (click)
        {
            showSpoiler = false;
            StartCoroutine(SpoilerPopUp());
            Vibration.Vibrate(50);
        }

    }

    IEnumerator SpoilerPopUp()
    {
        yield return new WaitForSeconds(0.5f);
        showSpoiler = true;
        textboxSpoilerAnim.SetTrigger("Show");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (click)
        {
            StopCoroutine(SpoilerPopUp());
            if (showSpoiler)
            {
                textboxSpoilerAnim.SetTrigger("Hide");
                showSpoiler = false;
            }
            else if (clickable)
            {
                bulbDisappearAnim.SetTrigger("Pop");
            }
        }

    }



}
