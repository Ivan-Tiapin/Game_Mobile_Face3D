using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSFace3DController : MonoBehaviour
{
    public SkinnedMeshRenderer[] faceParts;//path to meshrenderers of 3d model
    public Slider slider;
    public Animator animatorEyes;

    private SlideExecutor slideExecutor;
    public SkinnedMeshRenderer currentSMR;
    public float browS, browJx, browJy, noseS, noseJx, noseJy, mouthS, mouthJx,  mouthJy;

    //public GameObject slide;
    public float missK;

    public GameObject choiceBulbs;
    //public AudioSource audioSlider;
    //public AudioSource bulbSound;

    #region Face values
    private float _mouthLeft;
    public float mouthLeft { get { return _mouthLeft; } set { _mouthLeft = Mathf.Clamp(value, 0, 100f); } }
    private float _mouthRight;
    public float mouthRight { get { return _mouthRight; } set { _mouthRight = Mathf.Clamp(value, 0, 100f); } }


    private float _lu;
    public float lu { get { return _lu; } set { _lu = Mathf.Clamp(value, 0, 1f); } }
    private float _ru;
    public float ru { get { return _ru; } set { _ru = Mathf.Clamp(value, 0, 1f); } }
    private float _ld;
    public float ld { get { return _ld; } set { _ld = Mathf.Clamp(value, 0, 1f); } }
    private float _rd;
    public float rd { get { return _rd; } set { _rd = Mathf.Clamp(value, 0, 1f); } }

    private float _dLR;
    public float dLR { get { return _dLR; } set { _dLR = Mathf.Clamp(value, 0, 1f); } }
    private float _uLL;
    public float uLL { get { return _uLL; } set { _uLL = Mathf.Clamp(value, 0, 1f); } }
    private float _uLR;
    public float uLR { get { return _uLR; } set { _uLR = Mathf.Clamp(value, 0, 1f); } }
    private float _dLL;
    public float dLL { get { return _dLL; } set { _dLL = Mathf.Clamp(value, 0, 1f); } }
    private float _dRL;
    public float dRL { get { return _dRL; } set { _dRL = Mathf.Clamp(value, 0, 1f); } }
    private float _uRR;
    public float uRR { get { return _uRR; } set { _uRR = Mathf.Clamp(value, 0, 1f); } }
    private float _uRL;
    public float uRL { get { return _uRL; } set { _uRL = Mathf.Clamp(value, 0, 1f); } }
    private float _dRR;
    public float dRR { get { return _dRR; } set { _dRR = Mathf.Clamp(value, 0, 1f); } }
    #endregion



    public Animator animPartVictory;
    public Animator animWin;
    public Animator[] animsPartsFlash;


    private bool win;
    public bool tutorial;
    public int customStartFace, customStartSlider;
    
    public float[] targetValues;
    public int valueNumber = 0;
    public MSSlider msSlider;
    //private float currentTargetValue;

    #region Screenshot
    private Texture2D texture;
    public Image example;
    private Sprite sprite;
    //private SlideExecutor slideExecutor;
    #endregion
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        msSlider = slider.GetComponent<MSSlider>();
        if (!tutorial) 
        {
            BrowSlider(0);
            EyesSlider(0);
            NoseSlider(0);
            MouthSlider(0);
        }
        else
        {
            BrowSlider(customStartFace);
            EyesSlider(customStartFace);
            NoseSlider(customStartFace);
            MouthSlider(customStartFace);
        }
        valueNumber = 0;
        win = false;


    }


public void Slider(float value)
    {

        if (valueNumber == 0)
        {
            BrowSlider(value);
        }
        if (valueNumber == 1)
        {
            EyesSlider(value);
        }
        if (valueNumber == 2)
        {
            NoseSlider(value);
        }
        if (valueNumber == 3)
        {
            MouthSlider(value);
        }


    }
    public void BrowSlider(float value)
    {
        currentSMR = faceParts[0];
        browS = value;
        currentSMR.SetBlendShapeWeight(8, 70 * (1 - value)/2);
        currentSMR.SetBlendShapeWeight(9, 70 * (1 - value)/2);
        currentSMR.SetBlendShapeWeight(10, 85 * (1+value)/2);
        currentSMR.SetBlendShapeWeight(11, 85 * (1 + value) / 2);
        uRL = value;//6
        currentSMR.SetBlendShapeWeight(6, 40 * uRL);
        uRR = value;//5
        currentSMR.SetBlendShapeWeight(5, 40 * uRR);
        dLL = -value;//3
        currentSMR.SetBlendShapeWeight(3, 50 * dLL);
        dLR = -value;//0
        currentSMR.SetBlendShapeWeight(0, 50 * dLR);
    }
    public void EyesSlider(float value)
    {
        
        animatorEyes.SetFloat("Blend", (1+value)/2);
        animatorEyes.SetFloat("eyesX", value);
        animatorEyes.SetFloat("eyesY", 0.5f*value);

    }
    public void NoseSlider(float value)
    {
        currentSMR = faceParts[2];

        noseS = value;
        currentSMR.SetBlendShapeWeight(5, (1 + value) / 2 * 100);
        currentSMR.SetBlendShapeWeight(6, (1 - value) / 2 * 100);

        lu = 0.7f * -value;
        ru = 0.3f* value;
        rd = 0.7f * value;
        ld = -0.3f* value;
        currentSMR.SetBlendShapeWeight(0, lu * 100);//lu
        currentSMR.SetBlendShapeWeight(1, ru * 100);//ru
        currentSMR.SetBlendShapeWeight(2, rd * 100);//rd
        currentSMR.SetBlendShapeWeight(3, ld * 100);//ld
    }
    public void MouthSlider(float value)
    {

        mouthLeft =(1 + value) / 2;
        mouthRight = (1 - value) / 2;
        if (value > 0.5f)
        {
            mouthJx = value;
            mouthJy = -3.4f * value + 2.7f;
        }
        else if (value < -0.5f)
        {
            mouthJx = value;
            mouthJy = 3.4f * value + 2.7f;
        }
        else
        {
            mouthJx = value;
            mouthJy = 1;
        }

        currentSMR = faceParts[3];

        currentSMR.SetBlendShapeWeight(0, mouthLeft * 100 * Mathf.Clamp(mouthJy, 0, 1));//closed
        currentSMR.SetBlendShapeWeight(1, mouthRight * 100 * Mathf.Clamp(mouthJy, 0, 1));

        currentSMR.SetBlendShapeWeight(6, mouthLeft * 100 * Mathf.Clamp((1 - mouthJy) / 2, 0, 0.3f));//opened
        currentSMR.SetBlendShapeWeight(9, mouthRight * 100 * Mathf.Clamp((1 - mouthJy) / 2, 0, 0.3f));

        currentSMR.SetBlendShapeWeight(2, Mathf.Clamp((1 + mouthJy) / 2, 0, 1) * Mathf.Clamp((1 - mouthJx) * mouthRight * 100, 0, 100));//leftUpSmile
        currentSMR.SetBlendShapeWeight(3, Mathf.Clamp((1 + mouthJy) / 2, 0, 1) * Mathf.Clamp((1 + mouthJx) * mouthRight * 100, 0, 100));//rightUpSmile

        currentSMR.SetBlendShapeWeight(4, Mathf.Clamp((1 + mouthJy) / 2, 0, 1) * Mathf.Clamp((1 + mouthJx) * mouthLeft * 100, 0, 100));//rightDownFrown
        currentSMR.SetBlendShapeWeight(5, Mathf.Clamp((1 + mouthJy) / 2, 0, 1) * Mathf.Clamp((1 - mouthJx) * mouthLeft * 100, 0, 100));//leftdownfrown

        currentSMR.SetBlendShapeWeight(11, Mathf.Clamp((1 - mouthJy) / 2, 0, 1) * Mathf.Clamp((1 - mouthJx) * mouthRight * 100, 0, 100));//leftUpSmile
        currentSMR.SetBlendShapeWeight(10, Mathf.Clamp((1 - mouthJy) / 2, 0, 1) * Mathf.Clamp((1 + mouthJx) * mouthRight * 100, 0, 100));//rightUpSmile

        currentSMR.SetBlendShapeWeight(7, Mathf.Clamp((1 - mouthJy) / 2, 0, 1) * Mathf.Clamp((1 + mouthJx) * mouthLeft * 100, 0, 100));//rightDownFrown
        currentSMR.SetBlendShapeWeight(8, Mathf.Clamp((1 - mouthJy) / 2, 0, 1) * Mathf.Clamp((1 - mouthJx) * mouthLeft * 100, 0, 100));//leftdownfrown
        //WinCheck(value);

    }

    public void SetValues(float[] values)
    {
        targetValues = values;

        SendValues();
    }
    public void SendValues()
    {
        if (valueNumber < targetValues.Length)
        {
            if (targetValues[valueNumber] <= missK && targetValues[valueNumber] >= -missK)
            {

                if (valueNumber != 0)
                {
                    animsPartsFlash[valueNumber - 1].SetTrigger("Exit");
                }
                valueNumber++;
                SendValues();
            }
            else
            {
                if (valueNumber != 0)
                {
                    animPartVictory.SetTrigger("Show");
                    animsPartsFlash[valueNumber-1].SetTrigger("Exit");
                }

                msSlider.targetValue = targetValues[valueNumber];

                if (!tutorial)
                {
                    slider.value = 0;
                    msSlider.SliderColorChange(0);
                }
                else
                {
                    slider.value = customStartSlider;
                    msSlider.SliderColorChange(customStartSlider/50);
                }
                msSlider.animatorSlider.SetTrigger("Show");
                animsPartsFlash[valueNumber].enabled = true;


            }
        }
        else
        {
            animsPartsFlash[valueNumber - 1].SetTrigger("Exit");

            //fix
            win = true;
        }
        

    }

    public void WinCheck(float value)
    {
        
        if (value <= targetValues[valueNumber] + missK && value >= targetValues[valueNumber] - missK)
        {
            if (valueNumber < targetValues.Length-1)
            {
                valueNumber++;
                msSlider.animatorSlider.SetTrigger("Hide");
                msSlider.endDrag = true;
                SendValues();

            }
            else
            {

                msSlider.endDrag = true;

                animsPartsFlash[valueNumber].SetTrigger("Exit");
                win = true;
                msSlider.animatorSlider.SetTrigger("Hide");
                msSlider.endDrag = true;




            }

        }


    }

    public void Win()
    {

        if (win)
        {
            if (choiceBulbs != null) { choiceBulbs.SetActive(false); }
            slideExecutor = GetComponentInParent<SlideExecutor>();
            RenderTexture rt = new RenderTexture(Camera.main.pixelWidth, Camera.main.pixelHeight, 24);
            Camera.main.targetTexture = rt;
            texture = new Texture2D(Camera.main.pixelWidth, Camera.main.pixelHeight, TextureFormat.RGB24, false);
            Camera.main.Render();
            RenderTexture.active = rt;
            float delta = (Camera.main.pixelHeight - (Camera.main.pixelWidth * 16 / 9)) / 2;
            texture.ReadPixels(new Rect(0, 0, texture.width, Camera.main.pixelHeight - delta), 0, 0);
            texture.Apply();
            Camera.main.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);


            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height - delta * 2), new Vector2(0, 0));
            example.sprite = sprite;
            animWin.enabled = true;
        }


    }
}





