using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class MSSlider : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Slider slider;
    private MSFace3DController msFace3D;
    public Animator animatorSlider;
    public Image bgSlider;
    public float targetValue;
    public bool endDrag = false;
    public bool tutorial;
    private AudioSource audioSource;
    public GameObject hitZone;

    void Awake()
    {
        animatorSlider = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
        msFace3D = GetComponentInParent<MSFace3DController>();
        if (tutorial)
        {
            slider.value = 50;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        SliderColorChange(slider.value/50f);
        msFace3D.Slider(slider.value/50f);
        msFace3D.WinCheck(slider.value / 50f);
        Vibration.Vibrate(50);
        if (endDrag)
        {
            eventData.pointerDrag = null;
            OnEndDrag(eventData);
            endDrag = false;
        }
    }
    
    public void Dragging(float value)
    {
        SliderColorChange(slider.value / 50f);
        msFace3D.Slider(slider.value / 50f);

    }
    public void SliderColorChange(float sValue)
    {
        bgSlider.color = new Color32(0, (byte)(255 * ((2 - Mathf.Abs(targetValue - sValue)) / 2)), (byte)(255 - (255 * ((2 - Mathf.Abs(targetValue - sValue)) / 2))), 255);
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        audioSource.Stop();
        eventData.pointerDrag = null;
        
    }

    public void HitZ()
    {
        hitZone.SetActive(true);
        GetComponent<AudioSource>().enabled=true;
    }


}
