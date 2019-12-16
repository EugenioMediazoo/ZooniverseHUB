using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class NextButton : MonoBehaviour
{
    //cards
    public GameObject NextCardPivot;
    public GameObject PreviousCardPivot;

    //text
    public TextMeshProUGUI TMAdvancement;

    //Advancement
    public Slider Advancement;

    //animation
    [Range(0.1f, 5)]
    public float animationSpeed = 1;

    public void NextCard()
    {
        NextCardPivot.transform.DORotate(new Vector3(0, 0, 0), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutCubic);
        PreviousCardPivot.transform.DORotate(new Vector3(0, 0, 25), animationSpeed, RotateMode.Fast).SetEase(Ease.InOutCubic);

        Advancement.value++;
        //TM = TMAdvancement.GetComponent<TextMeshProUGUI>();
        TMAdvancement.SetText("{0}", Advancement.value);
    }
}
