using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManagerScript : MonoBehaviour
{
    //Images and gameObjects
    public Image CaseStudy;
    public Image About;
    public Image CaseStudyArrow;
    public Image AboutArrow;

    //public GameObject ContainerRatio;
    public RectTransform ContainerRatio;

    //time
    [Range(0.01f, 3f)]
    public float time;

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
                CaseStudy.transform.DOMoveY((screenHeight * 0.36f), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutBack);
            }
            else if (CaseStudyStatus && !AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight * 0.32f) * -1), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            else if (CaseStudyStatus && AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight * 0.32f) * -1), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);

                About.transform.DOMoveY(((screenHeight * 0.443f) * -1), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
        }
        else if (_ratio >= 2f)
        {
            if (!CaseStudyStatus)
            {
                CaseStudy.transform.DOMoveY((screenHeight / 2.5f), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutBack);
            }
            else if (CaseStudyStatus && !AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight / 3.59f) * -1), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            else if (CaseStudyStatus && AboutStatus)
            {
                CaseStudy.transform.DOMoveY(((screenHeight / 3.59f) * -1), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);

                About.transform.DOMoveY(((screenHeight / 2.57f) * -1), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
        }
    }

    public void AboutSlider()
    {
        if (_ratio <= 1.99f)
        {
            if (!AboutStatus && !CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight * 0.24f), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);

                CaseStudy.transform.DOMoveY((screenHeight * 0.36f), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            else if (!AboutStatus && CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight * 0.24f), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            else if (AboutStatus)
            {
                About.transform.DOMoveY(((screenHeight * 0.443f) * -1), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
        }
        else if (_ratio >= 2f)
        {
            if (AboutStatus)
            {
                About.transform.DOMoveY(((screenHeight / 2.57f) * -1), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            else if (!AboutStatus && CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight / 3.46f), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
            else if (!AboutStatus && !CaseStudyStatus)
            {
                About.transform.DOMoveY((screenHeight / 3.46f), time).SetEase(Ease.OutBack);
                AboutStatus = !AboutStatus;
                AboutArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);

                CaseStudy.transform.DOMoveY((screenHeight / 2.5f), time).SetEase(Ease.OutBack);
                CaseStudyStatus = !CaseStudyStatus;
                CaseStudyArrow.transform.DORotate(new Vector3(0, 0, 180), time, RotateMode.WorldAxisAdd).SetEase(Ease.OutBack);
            }
        }
    }

    public void ZooninverseScene()
    {
        GameObject _button = EventSystem.current.currentSelectedGameObject;
        if (_button != null)
        {
            if (_button.CompareTag("Zooniverse"))
            {
                SceneManager.LoadScene("ZooniverseAR", LoadSceneMode.Single);
                Debug.Log(_button.tag);
            }
            else
                Debug.Log("currentSelectedGameObject is untagged");
        }
    }

}
