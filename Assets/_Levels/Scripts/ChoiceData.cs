using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : MonoBehaviour
{
    public int forkNumberToSave, forkValueToSave;//1 - Vamp, 2-Waitress, 3 - Idol
    public GameObject otherButton;
    public float[] targetFaceValues;
    [SerializeField] private MSFace3DController face;
    [SerializeField] private SlidesController slidesController;
    private SaveLoad saveLoad;
    public bool saveDataFromPreviousFork;
    public int previousForkNumber;


    void Start()
    {

    }

    public void StartGame()
    {

        slidesController = GetComponentInParent<SlidesController>();
        face = GetComponentInParent<MSFace3DController>();
        if (saveDataFromPreviousFork)
        {
            forkValueToSave = slidesController.LoadForkData(previousForkNumber);
        }
        Debug.Log("1");
        Debug.Log(slidesController);
        slidesController.SaveForkData(forkNumberToSave, forkValueToSave);
        face.SetValues(targetFaceValues);
        if (otherButton != null)
        {
            Debug.Log("false");
            otherButton.SetActive(false);
        }
        gameObject.SetActive(false);
        face.slider.gameObject.GetComponent<Animator>().enabled = true;
    }
}
