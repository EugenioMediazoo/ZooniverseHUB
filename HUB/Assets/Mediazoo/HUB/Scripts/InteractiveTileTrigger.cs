using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class InteractiveTileTrigger : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler*/
{
    //public UnityEngine.Events.UnityEvent SceneLauncher;

    //public objects
    //public CanvasGroup CanvasG;
    public GameObject InteractiveTileObj;
    private CanvasGroup InteractiveTileCanvas;

    //SceneLauncher script
    public GameObject UIManager;
    SceneLauncher Scene;

    //Variables
    [Range(0.1f, 5)]
    public float AnimationSpeed = 0.12f;

    public void Awake()
    {
        InteractiveTileCanvas = InteractiveTileObj.GetComponent<CanvasGroup>();
        Scene = UIManager.GetComponent<SceneLauncher>();
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

    public void InteractiveTile()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => InteractiveTileCanvas.alpha, x => InteractiveTileCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad))
          .Append(DOTween.To(() => InteractiveTileCanvas.alpha, x => InteractiveTileCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad));

        StartCoroutine(LaunchScene());
    }
    IEnumerator LaunchScene()
    {
        yield return new WaitForSeconds(0.8f);
        Scene.LaunchSceene();
    }
}
