using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tut1Ini : MonoBehaviour
{
    private MSFace3DController face;
    public float[] targetFaceValues;

    void Start()
    {
        face = GetComponent<MSFace3DController>();
        StartCoroutine(Tutorial1Ini());
    }

    IEnumerator Tutorial1Ini()
    {
        yield return new WaitForSeconds(1);
        face.slider.gameObject.GetComponent<Animator>().enabled = true;
        face.SetValues(targetFaceValues);
    }
}
