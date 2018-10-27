using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Image currentHappiness;

    private float happyMax;
    private float maxHappiness;

    private void Start()
    {
        currentHappiness = GetComponent<Image>();
        UpdateHappiness();
    }

    private void UpdateHappiness()
    {
        float ratio = happyMax / maxHappiness;
        currentHappiness.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void DecreaseHappiness(float decreaseHappiness)
    {
        UpdateHappiness();
    }

    private void IncreaseHappiness(float increaseHappiness)
    {
        UpdateHappiness();
    }
}