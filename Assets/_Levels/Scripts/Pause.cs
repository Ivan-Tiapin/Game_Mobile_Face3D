using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public float musicDelay;
    void Start()
    {
        StartCoroutine(Delay(musicDelay));
    }
    IEnumerator Delay(float delay)
    {
        
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(delay);
        GetComponentInParent<SlideExecutor>().EventLauncher();
    }

}
