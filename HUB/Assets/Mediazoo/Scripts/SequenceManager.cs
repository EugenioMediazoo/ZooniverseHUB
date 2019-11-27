using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceManager : MonoBehaviour
{
    //questions array
    private GameObject[] Questions;
    private GameObject[] Sliders;

    //slider child
    //private GameObject slider;

    //value to skip
    public GameObject QuestionToSkip;
    private string Skip;
    private int I = 0;

    private int i;
    private int _i;


    //slider
    private Slider sliderValue;
    private float newValue;
    private float lastValue;

    void Awake()
    {
        Questions = GameObject.FindGameObjectsWithTag("Question");
        Skip = QuestionToSkip.name;

        Sliders = GameObject.FindGameObjectsWithTag("Slider");
        _i = 0;

        foreach (GameObject slider in Sliders)
        {
            sliderValue = slider.GetComponent<Slider>();
            //Debug.Log(sliderValue.name + ";" + sliderValue.value);
        }

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
        newValue = Sliders[_i].GetComponent<Slider>().value;
        lastValue = newValue;
        Debug.Log(Sliders[_i].GetComponent<Slider>().value +";"+ Sliders[_i].name);
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
                continue;
            }

            Questions[i].SetActive(false);
        }

        _i++;
        //Debug.Log("_i value" + _i);
    }

}
