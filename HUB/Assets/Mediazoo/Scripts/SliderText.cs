using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class SliderText : MonoBehaviour
{
    //text
    public TextMeshProUGUI TM;

    //button
    public Button button;
    private Image myButton;
    
    //sprite
    public Sprite ActiveButton;

    //slider
    private Slider slider;
    private float sliderValue;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();
        TM = TM.GetComponent<TextMeshProUGUI>();
        myButton = button.GetComponent<Button>().image;
    }

    public void updateText()
    {
        sliderValue = slider.value;
        TM.SetText("{0}", sliderValue);

        if (myButton.sprite.name != "ButtonActive")
        {
            myButton.sprite = ActiveButton;
        }
    }

}
