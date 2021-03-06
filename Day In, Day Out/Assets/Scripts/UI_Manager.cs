﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Image currentHappiness;
    public Text timer;
    Level1Manager manager;
    public Text aMessage;
    public Text bMessage;

    public Text messagec;
    public Text messaged;



    float minutes;
    float hours;

    public GameObject player;

    bool inBed;


    float ratio;

    public float timeMultiplyer;

    
    






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
        bMessage.text = "";
        messagec.text = "";
        messaged.text = "";
        minutes = 0;
        hours = 8;
        
        timer.text = hours + ":" + minutes.ToString("f0")+"AM";

        inBed = false;

    }

    private void Update()
    {
        if (inBed == false)
        {
            minutes += Time.deltaTime*timeMultiplyer;

            if (minutes >= 60)
            {
                hours++;
                minutes = 0;
            }
            if (hours > 12)
            {
                timer.text = "Sat " + (hours - 12f) + ":" + minutes.ToString("f0") + " PM";

            }
            else
            {
                timer.text = "Sat " + hours + ":" + minutes.ToString("f0") + " AM";
            }
        }
        else
        {
            minutes -= Time.deltaTime*100;

            if (minutes <= 0)
            {
                hours--;
                minutes = 59;
            }
            if (hours > 12)
            {
                timer.text = "Sat " + (hours - 12f) + ":" + minutes.ToString("f0") + " PM";

            }
            else
            {
                timer.text = "Sat " + hours + ":" + minutes.ToString("f0") + " AM";
            }

        }

        

        if(hours<7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }

    private void UpdateHappiness()
    {
         ratio = happyMax / maxHappiness;
       


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

    public void UpdateBMessage(string message, Color thecolor)
    {
        UpdateMessageC(bMessage.text, bMessage.color);
        bMessage.color = thecolor;

        bMessage.text = message;
    }

    public void SetInBed()
    {
        inBed = true;
    }
    public float getRatio()
    {
        return ratio;
    }
    public float GetHour()
    {
        return hours;
    }

    public void AddHour(float add)
    {
        hours += add;

    }

    private void UpdateMessageC(string text, Color cl)
    {
        UpdateMessageD(messagec.text, messagec.color);
        messagec.color = cl;
        messagec.text = text;
    }

    private void UpdateMessageD(string text, Color cl)
    {
        messaged.color = cl;
        messaged.text = text;
    }

}