using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tut2 : MonoBehaviour
{
    // Start is called before the first frame update
    public MSFace3DController face;
    public ChoiceData choice1,choice2;
    private FaceBulbChoice fbc1, fbc2;
    public Animator animCh2;
    public float[] valuesCh1, valuesCh2;
    void Start()
    {
        valuesCh1 = choice1.targetFaceValues;
        valuesCh2 = choice2.targetFaceValues;
        choice1.enabled = false;
        choice2.enabled = false;
        fbc1 = choice1.GetComponentInChildren<FaceBulbChoice>();
        fbc2 = choice2.GetComponentInChildren<FaceBulbChoice>();
    }

    public void Face1On()
    {
        face.BrowSlider(valuesCh1[0]);
        face.EyesSlider(valuesCh1[1]);
        face.NoseSlider(valuesCh1[2]);
        face.MouthSlider(valuesCh1[3]);
    }
    public void Face2On()
    {
        face.BrowSlider(valuesCh2[0]);
        face.EyesSlider(valuesCh2[1]);
        face.NoseSlider(valuesCh2[2]);
        face.MouthSlider(valuesCh2[3]);
    }
    public void FaceOff()
    {
        face.BrowSlider(0);
        face.EyesSlider(0);
        face.NoseSlider(0);
        face.MouthSlider(0);
    }

    IEnumerator ShowSpoiler()
    {
        animCh2.GetComponent<Animator>().SetTrigger("Show");
        yield return new WaitForSeconds(1);
        animCh2.GetComponent<Animator>().SetTrigger("Hide");
        choice1.enabled = true;
        choice2.enabled = true;
        yield return new WaitForSeconds(0.2f);
        



    }

    //// Update is called once per frame
    void Update()
    {
        if (fbc1.clickable == false || fbc2.clickable == false) { gameObject.SetActive(false); }
    }
}
