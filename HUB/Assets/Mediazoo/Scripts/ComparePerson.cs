using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ComparePerson : MonoBehaviour
{

    private GameObject[] Sliders;
    private float finalValue = 0;
    public GameObject Previous;
    public GameObject Adcanvement;

    [Range(0.1f, 5)]
    public float animationSpeed = 1;

    [Range(0,100)]
    public int PersonOne;
    public GameObject profileOne;
    public GameObject profileOneSlider;
    private int rOne;

    [Range(0, 100)]
    public int PersonTwo;
    public GameObject profileTwo;
    public GameObject profileTwoSlider;
    private int rTwo;

    [Range(0, 100)]
    public int PersonThree;
    public GameObject profileThree;
    public GameObject profileThreeSlider;
    private int rThree;

    private float percent;

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

        Adcanvement.transform.DORotate(new Vector3(0, 0, 25), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutCubic);
        Previous.transform.DORotate(new Vector3(0, 0, 25), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutCubic);

        rOne = (int) Mathf.Abs(finalValue - PersonOne);
        rTwo = (int)Mathf.Abs(finalValue - PersonTwo);
        rThree = (int)Mathf.Abs(finalValue - PersonThree);

        if (Mathf.Min(rOne, rTwo, rThree) == rOne)
        {
            profileOne.transform.DORotate(new Vector3(0, 0, 0), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutCubic);

            percent = Mathf.Abs(((100 * finalValue) / PersonOne) - 100);
            profileOneSlider.GetComponent<Slider>().value = (100 - percent);
        }
        else if (Mathf.Min(rOne, rTwo, rThree) == rTwo)
        {
            profileTwo.transform.DORotate(new Vector3(0, 0, 0), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutCubic);

            percent = Mathf.Abs(((100 * finalValue) / PersonTwo) - 100);
            profileTwoSlider.GetComponent<Slider>().value = (100 - percent);
        }
        else if (Mathf.Min(rOne, rTwo, rThree) == rThree)
        {
            profileThree.transform.DORotate(new Vector3(0, 0, 0), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutCubic);

            percent = Mathf.Abs(((100 * finalValue) / PersonThree) - 100);
            profileThreeSlider.GetComponent<Slider>().value = (100 - percent);
        }

    }
}
