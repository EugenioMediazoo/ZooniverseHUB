using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class QNA : MonoBehaviour
{
    //Paragraphs
    public GameObject QorA;

    //time
    [Range(0.01f, 3f)]
    public float time;

    public void Awake()
    {
        if (time == 0)
            time = 0.8f;
        else
            return;
    }

    public void Dialogue()
    {
        QorA.SetActive(true);
        var newTextCanvas = QorA.GetComponent<CanvasGroup>();
        DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuint);
    }

}
