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

    public void NextCard()
    {
        NextCardPivot.transform.DORotate(new Vector3(0, 0, 0), 1, RotateMode.Fast).SetEase(Ease.InOutCubic);
        PreviousCardPivot.transform.DORotate(new Vector3(0, 0, 25), 1, RotateMode.Fast).SetEase(Ease.InOutCubic);

        Advancement.value++;
        //TM = TMAdvancement.GetComponent<TextMeshProUGUI>();
        TMAdvancement.SetText("{0}", Advancement.value);
    }
}
