using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.iOS;

public class TypingEffect : MonoBehaviour
{

    public TextMeshProUGUI tx;
    private string m_text = "It was a very sunny day in the morning";
 
    //private string m_text;

    SwipeCartoon swipeCartoon;
    private int previousPage;
    


    void Start()
    {
        //m_text = gameObject.GetComponent<TextMeshProUGUI>().text;
        tx = gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(_typing());

        /*swipeCartoon = transform.parent.gameObject.GetComponent<SwipeCartoon>();
        if (swipeCartoon == null)
            Debug.Log("swipeCartoon is null");*/

        swipeCartoon = FindObjectOfType<SwipeCartoon>();
        previousPage = swipeCartoon.currentPage;
    }


    void Update()
    {
        int currentPage = swipeCartoon.currentPage;

        if (currentPage == 0)
        { 
            m_text = "It was a very sunny day in the morning";
        }
        else if(currentPage == 1) 
        {
            m_text = "But the Alarm weren't working";
        }
        else if (currentPage == 2) 
        {
            m_text = "Dammmmn,It's way past 9AM!";
        }
        else if (currentPage == 3) 
        {
            m_text = "Who the hell are these guys";
        }
        else if (currentPage == 4) 
        {
            m_text = "This must be a virus. I need to install a vaccine app";
        }
        else if (currentPage == 5 )
        {
            m_text = "Downloading AlarmFighter";
        }
        else if (currentPage == 6) 
        {
            m_text = "Swooooooooosh";
        }
        else if (currentPage == 7) 
        {
            m_text = "The Journey Begins";
        }
        else if (currentPage == 8) 
        {
            m_text = "";
        }

        if(previousPage != currentPage)
        {
            StartCoroutine(_typing());
        }
  

        previousPage = currentPage;


    }



    IEnumerator _typing()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);
          
            yield return new WaitForSeconds(0.05f);
        }
    }
}
