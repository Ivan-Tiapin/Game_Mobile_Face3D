using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulbHandler : MonoBehaviour
{
    private Dialogs dialogs;
    private AudioSource audioSource;
    private Animator animator;


    void Start()
    {

        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();

        dialogs = GetComponentInParent<Dialogs>();
    }

    public void BulbPopOut()
    {
        dialogs.BulbPopUp();
    }

    public void SkipBulb()
    {
        animator.SetTrigger("EndBulb");
    }
}
