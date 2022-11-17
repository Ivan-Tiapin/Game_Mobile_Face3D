using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio;

public class CallButton : MonoBehaviour
{
    private Button thisButton;
    private Animator animator;
    [HideInInspector] public bool clicked = false;
    private Phone phone;
    private int forkValue;
    private SlideExecutor slideExecutor;
    

    void Start()
    {
        phone = GetComponentInParent<Phone>();
        thisButton = GetComponent<Button>();
        animator = GetComponent<Animator>();
        slideExecutor = GetComponentInParent<SlideExecutor>();
    }
    public void ButtonClicked()
    {
        if (clicked == false)
        {
            clicked = true;
            for (int i = 0; i < phone.buttonsArray.Length; i++)
            {
                phone.buttonsArray[i].interactable = false;
            }
            phone.MakeACall(thisButton);
        }

    }

    public void UnlockContacts() //called from animator
    {
        for (int i = 0; i < phone.callButtonArray.Count; i++)
        {
            if(phone.callButtonArray[i].clicked == false)
            {
                phone.buttonsArray[i].interactable = true;
            }
        }
    }

    public void CallAnswered()
    {
        Debug.Log("s");
        slideExecutor.EventLauncher();
    }
}
