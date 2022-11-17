using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuLevelSlider : MonoBehaviour
{
    //public GameObject levelsBG;
    public RectTransform levelsBG;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ScrollBG(float value)
    {
        levelsBG.anchoredPosition = new Vector2(0, -63+4000 * value / 100);

    }
}
