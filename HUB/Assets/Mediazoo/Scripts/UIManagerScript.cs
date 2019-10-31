using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    //Images and gameObjects
    public Image CaseStudy;

    //time
    [Range(0.01f, 3f)]
    public float time;

    //Heights
    public float screenHeight = Screen.height;

    //bools
    private bool CaseStudyStatus;
    private bool AboutStatus;

    public bool ButtonTestB = false;

    private void Awake()
    {
        screenHeight = Screen.height;
        CaseStudyStatus = false;
        AboutStatus = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CaseStudySlider()
    {
        if (!CaseStudyStatus)
        {
            CaseStudy.transform.DOMoveY((screenHeight / 2f), time).SetEase(Ease.OutBack);
            CaseStudyStatus = !CaseStudyStatus;
        }
        else if(CaseStudyStatus)
        {
            CaseStudy.transform.DOMoveY(((screenHeight/2f)*-1), time).SetEase(Ease.OutBack);
            CaseStudyStatus = !CaseStudyStatus;
        }
    }

    public void AboutSlider()
    {
        if (!AboutStatus)
        {
            CaseStudy.transform.DOMoveY((screenHeight / 2f), time).SetEase(Ease.OutBack);
            AboutStatus = !AboutStatus;
        }
        else if (AboutStatus)
        {
            CaseStudy.transform.DOMoveY(((screenHeight / 2f) * -1), time).SetEase(Ease.OutBack);
            AboutStatus = !AboutStatus;
        }
    }

    }
