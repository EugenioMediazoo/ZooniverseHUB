using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeTest : MonoBehaviour
{
    //public objects
    //public CanvasGroup CanvasG;
    public GameObject CanvasTest;
    private CanvasGroup Test;

    //Variables
    [Range(0.1f, 5)]
    public float AnimationSpeed =1f;

    ////events
    //public UnityEngine.Events.UnityEvent ButtonDown;

    public void Awake()
    {
        Test = CanvasTest.GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        //CanvasG.GetComponent<CanvasGroup>();
        //DOTween.To(() => CanvasG.alpha, x => CanvasG.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
        DOTween.To(() => Test.alpha, x => Test.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
        Debug.Log("Pressed");
    }

    public void FadeOut()
    {
        //CanvasG.GetComponent<CanvasGroup>();
        //DOTween.To(() => CanvasG.alpha, x => CanvasG.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
        DOTween.To(() => Test.alpha, x => Test.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
    }
}
