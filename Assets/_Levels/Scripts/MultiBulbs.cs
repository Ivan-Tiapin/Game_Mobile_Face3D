using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBulbs : MonoBehaviour
{
    public GameObject[] multibulbs;
    // Start is called before the first frame update
    public void SkipBulb()
    {
        for(int i = 0; i < multibulbs.Length; i++)
        {
            multibulbs[i].GetComponent<Animator>().SetTrigger("EndBulb");

        }

    }
}
