using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class FadeObj : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler*/
{
    //public UnityEngine.Events.UnityEvent SceneLauncher;

    //public objects
    //public CanvasGroup CanvasG;
    public GameObject FadingObj;
    private CanvasGroup FadingCanvas;

    //SceneLauncher script
    public GameObject UIManager;
    SceneLauncher Scene;

    //Variables
    [Range(0.1f, 5)]
    public float AnimationSpeed = 0.12f;

    public void Awake()
    {
        FadingCanvas = FadingObj.GetComponent<CanvasGroup>();
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    DOTween.To(() => InteractiveTileCanvas.alpha, x => InteractiveTileCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
    //    //Debug.Log("P_UP");
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    DOTween.To(() => InteractiveTileCanvas.alpha, x => InteractiveTileCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
    //    //Scene.LaunchZooniverse();
    //    //Debug.Log("P_Down");
    //}

    public void FadeSprite()
    {
        if (FadingCanvas.alpha == 0)
            DOTween.To(() => FadingCanvas.alpha, x => FadingCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
        else if (FadingCanvas.alpha == 1)
            DOTween.To(() => FadingCanvas.alpha, x => FadingCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
    }
}
