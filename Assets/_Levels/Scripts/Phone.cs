using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private SlidesController slidesController;
    /*[HideInInspector] */public int forkValue;
    [HideInInspector] public Button[] buttonsArray;
    [HideInInspector] public List<CallButton> callButtonArray;

    void Start()
    {
        callButtonArray = new List<CallButton>();
        buttonsArray = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttonsArray.Length;i++)
        {
            callButtonArray.Add(buttonsArray[i].GetComponent<CallButton>());
        }
        slidesController = GetComponentInParent<SlidesController>();
        
    }

    public void MakeACall(Button button) 
    {
        forkValue = slidesController.LoadForkData(2);
        for (int i = 0; i < buttonsArray.Length; i++)
        {
            if (button == buttonsArray[i])
            {
                buttonsArray[i].interactable = false;
                if (i != forkValue-1)
                {
                    buttonsArray[i].animator.SetTrigger("Answer");
                    slidesController.SaveForkData(3, i + 1);
                }
                else
                {
                    buttonsArray[i].animator.SetTrigger("Deny");
                }
            }
        }
    }

}
