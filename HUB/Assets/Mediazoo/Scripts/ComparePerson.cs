using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ComparePerson : MonoBehaviour
{

    private GameObject[] Sliders;
    public float finalValue = 0;

    void Awake()
    {
        Sliders = GameObject.FindGameObjectsWithTag("Slider");
    }

    public void Results()
    {

        for (int i = 0; i < Sliders.Length; i++)
        {
            finalValue += Sliders[i].GetComponent<Slider>().value;
        }
    }
}
