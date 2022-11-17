using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour
{
    private Slider slider;
    private MSFace3DController face;
    private MSSlider msSlider;
    //public GameObject prot;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        face = GetComponentInParent<MSFace3DController>();
        msSlider = GetComponentInParent<MSSlider>();
        if (face.tutorial) { slider.GetComponent<Animator>().SetTrigger("Tutorial"); }
    }

    // Update is called once per frame
    public IEnumerator Down()
    {
        float goneTime = 0;
        while (goneTime < 0.25f)
        {
            slider.value = 50 - 40f*goneTime/0.25f;
            face.BrowSlider(slider.value/50);
            msSlider.SliderColorChange(slider.value / 50);
            goneTime += Time.deltaTime;
            yield return null;
        }
        slider.value = 10;
    }

    public IEnumerator Up()
    {
        float goneTime = 0;
        while (goneTime < 0.25f)
        {
            slider.value = 10 + 40f * goneTime / 0.25f;
            face.BrowSlider(slider.value/50);
            msSlider.SliderColorChange(slider.value / 50);

            goneTime += Time.deltaTime;
            yield return null;
        }
        slider.value = 50;
    }

    //public void Prot()
    //{
    //    prot.SetActive(true);
    //}
}
