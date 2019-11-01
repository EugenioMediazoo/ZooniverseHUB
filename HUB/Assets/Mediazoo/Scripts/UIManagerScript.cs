using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.EventSystems;

public class UIManagerScript : MonoBehaviour
{
    //Images and gameObjects
    public Image CaseStudy;
    public Image About;

    //time
    [Range(0.01f, 3f)]
    public float time;

    //Heights
    private float screenHeight = Screen.height;

    //bools
    private bool CaseStudyStatus;
    private bool AboutStatus;

    private void Awake()
    {
        screenHeight = Screen.height;
        CaseStudyStatus = false;
        AboutStatus = false;

        float ratio = Screen.width / Screen.height;

        if (ratio >= 0.45f)
        {
            Debug.Log("9:19.5");
        }
        else if (ratio >= 0.5f)
        {
            Debug.Log("9:18");
        }
        else if (ratio >= 0.55f)
        {
            Debug.Log("9:16");
        }
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
        else if (CaseStudyStatus)
        {
            CaseStudy.transform.DOMoveY(((screenHeight / 2f) * -1), time).SetEase(Ease.OutBack);
            CaseStudyStatus = !CaseStudyStatus;
        }
    }

    public void AboutSlider()
    {
        if (!AboutStatus)
        {
            About.transform.DOMoveY((screenHeight / 2f), time).SetEase(Ease.OutBack);
            AboutStatus = !AboutStatus;
        }
        else if (AboutStatus)
        {
            About.transform.DOMoveY(((screenHeight / 2f) * -1), time).SetEase(Ease.OutBack);
            AboutStatus = !AboutStatus;
        }
    }

    public void ZooninverseScene()
    {
        GameObject _button = EventSystem.current.currentSelectedGameObject;
        if (_button != null)
        {
            if (_button.CompareTag("Zooniverse"))
            {
                Debug.Log(_button.tag);
            }
        }
        else
            Debug.Log("currentSelectedGameObject is null");
    }

}
