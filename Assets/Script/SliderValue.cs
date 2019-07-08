using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderValue : MonoBehaviour
{
    Text sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        sliderValue = this.GetComponent<Text>();    
    }

    public void updateText(float value)
    {
        sliderValue.text = value.ToString();
    }
}
