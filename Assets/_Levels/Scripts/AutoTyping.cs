using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoTyping : MonoBehaviour
{
    public float eventStartTime;
    public float eventEndTime;
    public float typingSpeed;
    public float readTime;
    public TextAsset textFile;
    private AudioSource audioSource;
	public GameObject textbox;
    private string text;
    private Text message;
    private int clickCounter;
    private SlideExecutor slideExecutor;
    private IEnumerator type;
    private IEnumerator read;
    //private GlobalSettings globalSettings;

	void Start()
	{
        audioSource = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().interactable = false;
        slideExecutor = GetComponentInParent<SlideExecutor>();
        if (readTime == 0) { readTime = 2; };
        if (typingSpeed == 0) { typingSpeed = 0.05f; };
        //if (eventStartTime == 0) { eventStartTime = 0.25f; };
        //if (eventEndTime == 0) { eventEndTime = 0.25f; };
        message = textbox.GetComponent<Text>();
		message.text = "";
		text = textFile.ToString();
        type = TypeText();
        read = Read();
        audioSource.Play();
        StartCoroutine(EventStartDelay(eventStartTime));
    }
    IEnumerator EventStartDelay(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(type);
    }
   
    IEnumerator TypeText()
    {
        gameObject.GetComponent<Button>().interactable = true;
        foreach (char c in text)
        {
            message.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        audioSource.Stop();

        StartCoroutine(read);
    }

    IEnumerator Read()
    {
        message.text = "";
        message.text = text;
        yield return new WaitForSeconds(readTime);
        StartCoroutine(EventEndDelay(eventEndTime));
    }
    public void TextClick()
    {
        clickCounter++;
        if (clickCounter<= 2)
        {
            
            if (clickCounter == 1)
            {
                StopCoroutine(type);
                audioSource.Stop();
                message.text = "";
                message.text = text;
                StartCoroutine(read);
            }
            if (clickCounter == 2)
            {
                gameObject.GetComponent<Button>().interactable = false;

                StopCoroutine(type);
                message.text = "";
                message.text = text;
                audioSource.Stop();
                StopCoroutine(read);


                StartCoroutine(EventEndDelay(eventEndTime));
            }
        } 

    }
    IEnumerator EventEndDelay(float time)
    {
        yield return new WaitForSeconds(time);
        slideExecutor.EventLauncher();
    }



}
