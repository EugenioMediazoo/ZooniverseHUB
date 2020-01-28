using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerHUB : MonoBehaviour
{
    //placeholders
    public GameObject CaseStudyUpV;
    Vector3 CaseStudyUp;
    public GameObject CaseStudyDownV;
    Vector3 CaseStudyDown;
    public GameObject AboutUpV;
    Vector3 AboutUp;
    public GameObject AboutDownV;
    Vector3 AboutDown;

    public GameObject InteractiveTiles;

    public GameObject InteractiveTilesUpV;
    Vector3 InteractiveTilesUp;
    public GameObject InteractiveTilesDownV;
    Vector3 InteractiveTilesDown;


    //Images and gameObjects
    public Image CaseStudy;
    public Image About;

    public Image CaseStudyArrow;
    public GameObject CaseStudyButtonObj;
    private CanvasGroup CaseStudyButtonCanvas;

    public Image AboutArrow;
    public GameObject AboutButtonObj;
    private CanvasGroup AboutButtonCanvas;

    


    //time
    [Range(0.01f, 3f)]
    public float time;

    //Variables
    [Range(0.1f, 5)]
    public float AnimationSpeed = 0.12f;

    //Heights
    private float screenHeight;
    private float screenWidth;

    //bools
    public bool CaseStudyStatus;
    public bool AboutStatus;

    private void Awake()
    {
        CaseStudyStatus = false;
        AboutStatus = false;

        CaseStudyUp = CaseStudyUpV.transform.position;
        CaseStudyDown = CaseStudyDownV.transform.position;
        AboutUp = AboutUpV.transform.position;
        AboutDown = AboutDownV.transform.position;

        InteractiveTilesUp = InteractiveTilesUpV.transform.position;
        InteractiveTilesDown = InteractiveTilesDownV.transform.position;

        InteractiveTiles.transform.position = new Vector3(InteractiveTiles.transform.position.x, InteractiveTilesDown.y, InteractiveTiles.transform.position.z);

        CaseStudy.transform.position = CaseStudyDown;
        About.transform.position = AboutDown;

        CaseStudyButtonCanvas = CaseStudyButtonObj.GetComponent<CanvasGroup>();
        AboutButtonCanvas = AboutButtonObj.GetComponent<CanvasGroup>();
    }

    public void CaseStudySlider()
    {
        if (!CaseStudyStatus)
        {
            CaseStudy.transform.DOMoveY(CaseStudyUp.y, time).SetEase(Ease.InOutCirc);
            CaseStudyStatus = !CaseStudyStatus;
            CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);

            InteractiveTiles.transform.DOMoveY(InteractiveTilesUp.y, time).SetEase(Ease.InOutCirc);
        }
        else if (CaseStudyStatus && !AboutStatus)
        {
            CaseStudy.transform.DOMoveY(CaseStudyDown.y, time).SetEase(Ease.InOutCirc);
            CaseStudyStatus = !CaseStudyStatus;
            CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);

            InteractiveTiles.transform.DOMoveY(InteractiveTilesDown.y, time).SetEase(Ease.InOutCirc);
        }
        else if (CaseStudyStatus && AboutStatus)
        {
            CaseStudy.transform.DOMoveY(CaseStudyDown.y, time).SetEase(Ease.InOutCirc);
            CaseStudyStatus = !CaseStudyStatus;
            CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);

            InteractiveTiles.transform.DOMoveY(InteractiveTilesDown.y, time).SetEase(Ease.InOutCirc);

            About.transform.DOMoveY(AboutDown.y, time).SetEase(Ease.InOutCirc);
            AboutStatus = !AboutStatus;
            AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
        }
    }

    public void AboutSlider()
    {

        if (!AboutStatus && !CaseStudyStatus)
        {
            About.transform.DOMoveY(AboutUp.y, time).SetEase(Ease.InOutCirc);
            AboutStatus = !AboutStatus;
            AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);

            InteractiveTiles.transform.DOMoveY(InteractiveTilesUp.y, time).SetEase(Ease.InOutCirc);

            CaseStudy.transform.DOMoveY(CaseStudyUp.y, time).SetEase(Ease.InOutCirc);
            CaseStudyStatus = !CaseStudyStatus;
            CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
        }
        else if (!AboutStatus && CaseStudyStatus)
        {
            About.transform.DOMoveY(AboutUp.y, time).SetEase(Ease.InOutCirc);
            AboutStatus = !AboutStatus;
            AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
        }
        else if (AboutStatus)
        {
            About.transform.DOMoveY(AboutDown.y, time).SetEase(Ease.InOutCirc);
            AboutStatus = !AboutStatus;
            AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
            DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
        }

    }

}
