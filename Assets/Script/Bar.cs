using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    /*
     * Bar class
     * How to use:
     * 1. Update Start method. Change MaxValue to maximumValue and this.Value to currentValue
     * 2. To update the progress just call Bar.Value = newValue;
     * Used by: Profile/Water_background/WaterBar WHERE [Home.scene] WHEN drinkWater(method)
     */

    private Image content;
    private float fillAmount;
    private float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = ConvertFillAmount(value, MaxValue);
        }
    }

    void Start()
    {
        content = GetComponent<Image>();
        MaxValue = Player.instance.WaterGoal;
        this.Value = Player.instance.WaterDrankToday;
    }

    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if (content.fillAmount != fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * 3);
        }
    }

    private float ConvertFillAmount(float currentAmount, float totalAmount)
    {
        return currentAmount / totalAmount;
    }
}
