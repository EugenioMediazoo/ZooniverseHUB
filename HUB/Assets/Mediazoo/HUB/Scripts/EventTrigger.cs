using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class EventTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEngine.Events.UnityEvent SceneLauncher;

    //public objects
    //public CanvasGroup CanvasG;
    public GameObject CanvasGObj;
    private CanvasGroup canvasGroup;

    //Variables
    [Range(0.1f, 5)]
    public float AnimationSpeed = 1f;

    public void Awake()
    {
        canvasGroup = CanvasGObj.GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
        //Debug.Log("P_UP");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
        SceneLauncher.Invoke();
        //Debug.Log("P_Down");
    }
}
