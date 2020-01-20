using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ParagraphManager : MonoBehaviour
{
    ////Paragraphs
    //public GameObject[] ParagraphOne;
    //public GameObject Options;

    //public GameObject Hid;
    //public GameObject Show;

    public GameObject Starter;
    public GameObject Hide;

    public GameObject OptionOneContainer;


    //time
    [Range(0.01f, 3f)]
    public float time;

    ////debug
    //public bool test = false;

    public void Awake()
    {
        if (time == 0)
            time = 0.8f;
        else
            return;
    }

    private void Start()
    {
        Invoke("_Starter", 4);
    }

    public void _Starter()
    {
        Starter.SetActive(true);
        var newTextCanvas = Starter.GetComponent<CanvasGroup>();
        DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuint);
    }

    public void OptionOne()
    {
        OptionOneContainer.SetActive(true);
        OptionOneContainer.transform.DOMoveY(Hide.transform.position.y, time / 2).SetEase(Ease.InQuint);
    }

    #region Debug
    //private void Update()
    //{
    //    if (test)
    //    {
    //        test = false;

    //        Q1();
    //    }
    //}

    //public void POne()
    //{
    //    test = false;
    //    ParagraphOne[0].transform.DOScale(1, time).SetEase(Ease.InQuad);

    //    Sequence myQuestions = DOTween.Sequence();
    //    myQuestions.Append(ParagraphOne[0].transform.DOScale(1, time).SetEase(Ease.InQuint))
    //        .Append(ParagraphOne[1].transform.DOScale(1, time).SetEase(Ease.InQuint))
    //        .Append(ParagraphOne[2].transform.DOScale(1, time).SetEase(Ease.InQuint))
    //        .Append(ParagraphOne[3].transform.DOScale(1, time).SetEase(Ease.InQuint))
    //        .Append(Options.transform.DOMoveY(Show.transform.position.y, time).SetEase(Ease.InQuint));
    //}
    #endregion

    #region Q1etc
    //public void Q1()
    //{
    //    ParagraphOne[0].SetActive(true);
    //    var newTextCanvas = ParagraphOne[0].GetComponent<CanvasGroup>();
    //    DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuint);

    //    Invoke("Q2", 1);
    //}

    //public void Q2()
    //{
    //    ParagraphOne[1].SetActive(true);
    //    var newTextCanvas = ParagraphOne[1].GetComponent<CanvasGroup>();
    //    DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuint);

    //    Invoke("Q3", 1);
    //}

    //public void Q3()
    //{
    //    ParagraphOne[2].SetActive(true);
    //    var newTextCanvas = ParagraphOne[2].GetComponent<CanvasGroup>();
    //    DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuint);

    //    Invoke("Q4", 1);
    //}

    //public void Q4()
    //{
    //    ParagraphOne[3].SetActive(true);
    //    var newTextCanvas = ParagraphOne[3].GetComponent<CanvasGroup>();
    //    DOTween.To(() => newTextCanvas.alpha, x => newTextCanvas.alpha = x, 1, time).SetEase(Ease.InQuint);

    //    Options.SetActive(true);
    //    Options.transform.DOMoveY(Show.transform.position.y, time).SetEase(Ease.InQuint);
    //}
    #endregion
}
