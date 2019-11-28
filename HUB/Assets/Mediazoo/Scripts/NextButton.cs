using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NextButton : MonoBehaviour
{
    public GameObject NextCardPivot;
    public GameObject PreviousCardPivot;

    public void NextCard()
    {
        NextCardPivot.transform.DORotate(new Vector3(0, 0, 0), 1, RotateMode.Fast).SetEase(Ease.InOutCubic);
        PreviousCardPivot.transform.DORotate(new Vector3(0, 0, 25), 1, RotateMode.Fast).SetEase(Ease.InOutCubic);
    }
}
