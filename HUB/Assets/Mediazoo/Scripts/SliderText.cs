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
    private Button myButton;
    private Image buttonSprite;
    
    //sprite
    public Sprite ActiveButton;

    //slider
    private Slider slider;
    private float sliderValue;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();
        TM = TM.GetComponent<TextMeshProUGUI>();
        buttonSprite = button.GetComponent<Button>().image;
        myButton = button.GetComponent<Button>();
        
        myButton.enabled = false;
    }

    public void updateText()
    {
        sliderValue = slider.value;
        TM.SetText("{0}", sliderValue);

        if (buttonSprite.sprite.name != "ButtonActive")
        {
            buttonSprite.sprite = ActiveButton;
            myButton.enabled = true;
        }
    }

}
