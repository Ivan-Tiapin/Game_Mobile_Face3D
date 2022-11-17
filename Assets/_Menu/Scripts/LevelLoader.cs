using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LevelLoader : MonoBehaviour, IPointerClickHandler
{
    private MenuScenesLoader menuScenesLoader;//MSL
    private Button thisButton;
    public int[] slidesNumbers;
    [HideInInspector] public int thisLevelScene,currentSlide;//from parent

    void Start()
    {
        thisButton = GetComponent<Button>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (thisButton.interactable)
        {
            menuScenesLoader = GetComponentInParent<MenuScenesLoader>();

            menuScenesLoader.LoadLevel(thisLevelScene, currentSlide);
        }

    }
}
