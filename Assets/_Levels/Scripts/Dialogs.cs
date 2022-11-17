using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
    public float eventStartTime;
    public float eventEndTime;
    private BulbHandler[] bulbSlides;
    public List<GameObject> bulbs;
    private int currentBulb = 0;
    private SlideExecutor slideExecutor;
    private MultiBulbs multiBulbs;
    void Start()
    {
        bulbs.Clear();
        bulbSlides = GetComponentsInChildren<BulbHandler>(true);
        foreach (BulbHandler bulb in bulbSlides)
        {
            bulbs.Add(bulb.gameObject);
        }
        //bulbs.Add(GetComponentInChildren<MultiBulbs>(true).gameObject);
        slideExecutor = GetComponentInParent<SlideExecutor>();
        StartCoroutine(EventStartDelay(eventStartTime));
    }

    IEnumerator EventStartDelay(float time)
    {
        yield return new WaitForSeconds(time);
        BulbPopUp();
    }
    public void BulbPopUp()
    {
        Debug.Log("Bilb");
        if (currentBulb == 0)
        {
            bulbs[currentBulb].SetActive(true);
        }
        else
        {
            if (currentBulb < bulbs.Count)
            {
                bulbs[currentBulb - 1].SetActive(false);
                bulbs[currentBulb].SetActive(true);
            }
            else
            {
                bulbs[currentBulb - 1].SetActive(false);
                StartCoroutine(EventEndDelay(eventEndTime));
                GetComponentInChildren<Button>().interactable = false;
                return;
            }
        }
        currentBulb++;
    }

    IEnumerator EventEndDelay(float time)
    {
        yield return new WaitForSeconds(time);
        slideExecutor.EventLauncher();
    }

    public void NextBulb()
    {
        if (currentBulb < bulbs.Count+1)
        {
            if (bulbs[currentBulb - 1].GetComponent<BulbHandler>())
            {
                bulbs[currentBulb - 1].GetComponent<BulbHandler>().SkipBulb();
            }
            else 
            {
                if (bulbs[currentBulb - 1].GetComponent<MultiBulbs>())
                {
                    bulbs[currentBulb - 1].GetComponent<MultiBulbs>().SkipBulb();
                }
            }

        }
    }
}
