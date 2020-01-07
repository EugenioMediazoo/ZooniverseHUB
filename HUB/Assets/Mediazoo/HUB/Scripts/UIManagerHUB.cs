using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerHUB : MonoBehaviour
{
    //Images and gameObjects
    public Image CaseStudy;
    public Image About;
    public Image CaseStudyArrow;
        //public CanvasGroup CanvasG;
        public GameObject CaseStudyButtonObj;
        private CanvasGroup CaseStudyButtonCanvas;
    public Image AboutArrow;
        //public CanvasGroup CanvasG;
        public GameObject AboutButtonObj;
        private CanvasGroup AboutButtonCanvas;

    public CanvasGroup InteractiveTiles;

    //public GameObject ContainerRatio;
    public RectTransform ContainerRatio;

    //Vector3
    private Vector3 CurrentPos;

    //time
    [Range(0.01f, 3f)]
    public float time;

    //Variables
    [Range(0.1f, 5)]
    public float AnimationSpeed = 0.12f;

    //Heights
    private float screenHeight;
    private float screenWidth;
    private float _ratio;

    //bools
    public bool CaseStudyStatus;
    public bool AboutStatus;

    private void Awake()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        CaseStudyStatus = false;
        AboutStatus = false;

        _ratio = Screen.height / Screen.width;
        Debug.Log(_ratio + "," + Screen.width + "," + Screen.height);

        if (_ratio >= .9f && _ratio <= 1.99f)
        {
            Debug.Log("9:16");

            ContainerRatio.anchoredPosition = new Vector2(0, 200f);
            Debug.Log(ContainerRatio.anchoredPosition);
        }
        else if (_ratio >= 2f && _ratio <= 2.09f)
        {
            Debug.Log("9:18");
            Debug.Log(ContainerRatio.anchoredPosition);
        }
        else /*if (ratio >= 2.15f)*/
        {
            Debug.Log("9:19.5");

            ContainerRatio.anchoredPosition = new Vector2(0, -200f);
            Debug.Log(ContainerRatio.anchoredPosition);
        }

        CurrentPos = InteractiveTiles.transform.position;

        CaseStudyButtonCanvas = CaseStudyButtonObj.GetComponent<CanvasGroup>();
        AboutButtonCanvas = AboutButtonObj.GetComponent<CanvasGroup>();
    }

    #region START
    //void Start()
    //{
    //    ratio = Screen.height / Screen.width;
    //    Debug.Log(ratio + "," + Screen.width + "," + Screen.height);

    //    if (ratio >= .9f && ratio <= 1.99f)
    //    {
    //        Debug.Log("9:16");

    //        ContainerRatio.anchoredPosition = new Vector2(0, 200f);
    //        Debug.Log(ContainerRatio.anchoredPosition);
    //    }
    //    else if (ratio >= 2f && ratio <= 2.09f)
    //    {
    //        Debug.Log("9:18");
    //        Debug.Log(ContainerRatio.anchoredPosition);

    //    }
    //    else
    //    {
    //        Debug.Log("9:19.5");

    //        ContainerRatio.anchoredPosition = new Vector2(0, -200f);
    //        Debug.Log(ContainerRatio.anchoredPosition);
    //    }
    //}
    #endregion

    #region UPDATE
    //private void Update()
    //{
    //    Debug.Log(Screen.height + "," + Screen.width);
    //    Debug.Log(ratio);
    //}
    #endregion

    public void CaseStudySlider()
    {
        Debug.Log(_ratio);

        if (_ratio <= 1.99f)
        {
            if (!CaseStudyStatus)
            {
                CaseStudy.transform.DOMoveY((screenHeight * 0.36f), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOLocalMoveY((screenHeight * 1.8f), time).SetEase(Ease.InOutCirc);
            }
            else if (CaseStudyStatus && !AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight * 0.32f) * -1), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOMoveY(CurrentPos.y,time).SetEase(Ease.InOutCirc);
            }
            else if (CaseStudyStatus && AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight * 0.32f) * -1), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOMoveY(CurrentPos.y, time).SetEase(Ease.InOutCirc);

                About.transform.DOMoveY(((screenHeight * 0.443f) * -1), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
            }
        }
        else if (_ratio >= 2f)
        {
            if (!CaseStudyStatus)
            {
                CaseStudy.transform.DOMoveY((screenHeight / 2.5f), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOLocalMoveY((screenHeight * 2f), time).SetEase(Ease.InOutCirc);
            }
            else if (CaseStudyStatus && !AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight / 3.59f) * -1), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOMoveY(CurrentPos.y, time).SetEase(Ease.InOutCirc);
            }
            else if (CaseStudyStatus && AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight / 3.59f) * -1), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOMoveY(CurrentPos.y, time).SetEase(Ease.InOutCirc);

                About.transform.DOMoveY(((screenHeight / 2.57f) * -1), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
            }
        }
    }

    public void AboutSlider()
    {
        if (_ratio <= 1.99f)
        {
            if (!AboutStatus && !CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight * 0.24f), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOLocalMoveY((screenHeight * 1.8f), time).SetEase(Ease.InOutCirc);

                CaseStudy.transform.DOMoveY((screenHeight * 0.36f), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
            }
            else if (!AboutStatus && CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight * 0.24f), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
            }
            else if (AboutStatus)
            {
                About.transform.DOMoveY(((screenHeight * 0.443f) * -1), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
            }
        }
        else if (_ratio >= 2f)
        {
            if (AboutStatus)
            {
                About.transform.DOMoveY(((screenHeight / 2.57f) * -1), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 0, AnimationSpeed).SetEase(Ease.InQuad);
            }
            else if (!AboutStatus && CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight / 3.46f), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
            }
            else if (!AboutStatus && !CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight / 3.46f), time).SetEase(Ease.InOutCirc);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => AboutButtonCanvas.alpha, x => AboutButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);

                InteractiveTiles.transform.DOLocalMoveY((screenHeight * 2f), time).SetEase(Ease.InOutCirc);

                CaseStudy.transform.DOMoveY((screenHeight / 2.5f), time).SetEase(Ease.InOutCirc);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCirc);
                DOTween.To(() => CaseStudyButtonCanvas.alpha, x => CaseStudyButtonCanvas.alpha = x, 1, AnimationSpeed).SetEase(Ease.InQuad);
            }
        }
    }

}
