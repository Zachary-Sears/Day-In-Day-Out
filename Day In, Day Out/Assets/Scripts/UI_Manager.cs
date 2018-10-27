using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Image currentHappiness;
    public Text timer;
    Level1Manager manager;
    public Text aMessage;

    float minutes;
    float hours;
    
    

     private float happyMax;
    private float maxHappiness;

    private void Start()
    {
        //currentHappiness = GetComponent<Image>();
        manager = GetComponent<Level1Manager>();
        
        
        happyMax = 100f;
        maxHappiness = 100f;
        UpdateHappiness();
        aMessage.text = "Good Morning";
        minutes = 0;
        hours = 7;
        timer.text = hours + ":" + minutes;

    }

    private void Update()
    {
        minutes += Time.deltaTime;
        if(minutes >= 60)
        {
            hours++;
            minutes = 0;
        }
        timer.text = hours + ":" + minutes;


    }

    private void UpdateTime()
    {
        while (manager.timeStart > 0)
        {

        }
    }
    private void UpdateHappiness()
    {
        float ratio = happyMax / maxHappiness;
       


        currentHappiness.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
    }

    public void DecreaseHappiness(float decreaseHappiness)
    {
        happyMax -= decreaseHappiness;
        happyMax = Mathf.Max(0, happyMax);
        UpdateHappiness();
    }

    public void IncreaseHappiness(float increaseHappiness)
    {
        happyMax += increaseHappiness;
        happyMax = Mathf.Min(100, happyMax);
        UpdateHappiness();
    }

    public void UpdateMessage(string message)
    {
        aMessage.text = message;
    }
}