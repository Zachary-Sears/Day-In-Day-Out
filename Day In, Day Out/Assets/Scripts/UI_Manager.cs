using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Image currentHappiness;
    public Text text;
    Level1Manager manager;

     private float happyMax;
    private float maxHappiness;

    private void Start()
    {
        //currentHappiness = GetComponent<Image>();
        manager = GetComponent<Level1Manager>();
        
        happyMax = 100f;
        maxHappiness = 100f;
        UpdateHappiness();

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
}