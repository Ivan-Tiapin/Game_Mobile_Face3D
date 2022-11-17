using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallWinCheck : MonoBehaviour
{
    private MSFace3DController msFace;
    private Slider slider;

    private void Start()
    {
        msFace = GetComponentInParent<MSFace3DController>();
        slider = GetComponent<Slider>();
    }

    public void WinCheck()
    {

        msFace.Win();
    }
}
