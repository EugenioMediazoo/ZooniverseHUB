using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SequenceManager : MonoBehaviour
{
    //questions array
    private GameObject[] Questions;
    private GameObject[] Sliders;
    public GameObject[] TMs;

    //slider child
    //private GameObject slider;

    //value to skip
    public GameObject QuestionToSkip;
    private string Skip;
    private int I = 0;

    private int i;
    private int _i;


    //slider
    //private Slider sliders;
    //private TextMeshProUGUI TMS;
    private float newSliderValue;
    //private float lastValue;

    void Awake()
    {
        Questions = GameObject.FindGameObjectsWithTag("Question");
        Skip = QuestionToSkip.name;

        Sliders = GameObject.FindGameObjectsWithTag("Slider");
        _i = 0;

        TMs = GameObject.FindGameObjectsWithTag("TM");
        //slider = this.GetComponent<Slider>();

        foreach (GameObject slider in Sliders)
        {
            //sliders = slider.GetComponent<Slider>();
            //Debug.Log(sliderValue.name + ";" + sliderValue.value);
        }

        //foreach (GameObject TM in TMs)
        //{
        //    TMS = TM.GetComponent<TextMeshProUGUI>();
        //}

        foreach (GameObject question in Questions)
        {
            if (question.name == Skip)
                continue;

            question.SetActive(false);
            //Debug.Log("Q Number is named " + question.name);
        }
    }

    public void OnValueChanged()
    {
        newSliderValue = Sliders[_i].GetComponent<Slider>().value;
        Debug.Log(newSliderValue);
        //lastValue = newValue;
        //Debug.Log(Sliders[_i].GetComponent<Slider>().value +";"+ Sliders[_i].name);

        //sliderValue = slider.value;
        TMs[_i].GetComponent<TextMeshProUGUI>().SetText("{0}", newSliderValue);
        //TMS.SetText("{0}", newSliderValue);
    }

    public void ActivateNext()
    {
        I++;
        Debug.Log(I);

        for (i=0; i < Questions.Length; i++)
        {
            if (Questions[i] == Questions[I])
            {
                Questions[I].SetActive(true);

                Questions[I].transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.Fast).SetEase(Ease.InOutCubic);
                continue;
            }

            Questions[i].transform.DORotate(new Vector3(0, 0, 30), 1.5f, RotateMode.Fast).SetEase(Ease.InOutCubic);
            //Questions[i].SetActive(false);
        }
        Invoke("DeactivateUsed", 2.0f);
        _i++;
        //Debug.Log("_i value" + _i);
    }

    void DeactivateUsed()
    {
        Questions[i].SetActive(false);
    }

}
