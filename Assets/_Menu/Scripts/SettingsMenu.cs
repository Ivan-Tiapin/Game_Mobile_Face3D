using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour

{
    public Sprite onButton;
    public Sprite offButton;
    public GameObject soundButton;
    public GameObject vibrationButton;

    private Image soundImage, vibrationImage;
    private Text soundText, vibrationText;
    public SaveLoad saveLoad;

    void Awake()
    {
        soundImage = soundButton.GetComponent<Image>();
        soundText = soundButton.GetComponentInChildren<Text>();
        vibrationImage = vibrationButton.GetComponent<Image>();
        vibrationText = vibrationButton.GetComponentInChildren<Text>();

    }
    private void OnEnable()
    {
        Debug.Log("Alfa");
        if (AudioListener.volume == 0)
        {
            soundImage.sprite = offButton;
            soundText.text = "Sound Off";
        }
        else
        {
            soundImage.sprite = onButton;
            soundText.text = "Sound On";
        }
        if (Vibration.doesVibrate == 0)
        {
            vibrationImage.sprite = offButton;
            vibrationText.text = "Vibration Off";
        }
        else
        {
            vibrationImage.sprite = onButton;
            vibrationText.text = "Vibration On";
        }
    }
    public void SoundButton()
    {

        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            soundImage.sprite = offButton;
            soundText.text = "Sound Off";
            saveLoad.sound = 0;
            saveLoad.SaveGame();

        }
        else
        {
            AudioListener.volume = 1;
            soundImage.sprite = onButton;
            soundText.text = "Sound On";
            saveLoad.sound = 1;
            saveLoad.SaveGame();
        }
    }

    public void VibrationButton()
    {
        if (Vibration.doesVibrate == 1)
        {
            vibrationImage.sprite = offButton;
            vibrationText.text = "Vibration Off";
            Vibration.doesVibrate = 0;
            saveLoad.vibration = 0;
            saveLoad.SaveGame();
        }
        else
        {
            vibrationImage.sprite = onButton;
            vibrationText.text = "Vibration On";
            Vibration.doesVibrate = 1;
            saveLoad.vibration = 1;
            saveLoad.SaveGame();

        }
    }



}
