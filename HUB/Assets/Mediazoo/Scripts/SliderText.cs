using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderText : MonoBehaviour
{
    public TextMeshProUGUI TM;

    private Slider slider;
    private float sliderValue;



    private void Awake()
    {
        slider = this.GetComponent<Slider>();
        TM = TM.GetComponent<TextMeshProUGUI>();
    }

    public void updateText()
    {
        sliderValue = slider.value;

        TM.SetText("{0}", slider.value);

    }
}
