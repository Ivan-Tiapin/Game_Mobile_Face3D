using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut2ButtonEnabler : MonoBehaviour
{
    public FaceBulbChoice fbc1, fbc2;
    // Start is called before the first frame update
    void Start()
    {
        fbc1.click = true;
        fbc2.click = true;
    }


}
