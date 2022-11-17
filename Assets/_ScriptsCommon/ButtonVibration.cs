using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVibration : MonoBehaviour
{
    public long vibrationTime;

    
    public void VibrateButton()
    {
        Vibration.Vibrate(vibrationTime);
    }
}
