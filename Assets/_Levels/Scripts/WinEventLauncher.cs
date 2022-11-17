using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEventLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    private SlideExecutor slideExecutor;
    void Start()
    {
        slideExecutor = GetComponentInParent<SlideExecutor>();
    }

    // Update is called once per frame

    public IEnumerator EventLaunch()
    {
        yield return new WaitForSeconds(0.5f);
        slideExecutor.EventLauncher();

    }
}
