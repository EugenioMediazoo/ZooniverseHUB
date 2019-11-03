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
    }

    // Start is called before the first frame update
    void Start()
    {
        double ratio = Screen.height / Screen.width;
        Debug.Log(ratio + "," + Screen.width + "," + Screen.height);

        if (ratio >= .9f && ratio <= 1.99f)
        {
            Debug.Log("9:16");
        }
        else if (ratio >= 2f && ratio<= 2.14f)
        {
            Debug.Log("9:18");
        }
        else if (ratio >= 2.15f)
        {
            Debug.Log("9:19.5");
        }
    }

    public void CaseStudySlider()
    {
        if (!CaseStudyStatus)
        {
            CaseStudy.transform.DOMoveY((screenHeight / 2.5f), time).SetEase(Ease.OutBack);
            CaseStudyStatus = !CaseStudyStatus;
        }
        else if (CaseStudyStatus)
        {
            CaseStudy.transform.DOMoveY(((screenHeight / 3.59f) * -1), time).SetEase(Ease.OutBack);
            CaseStudyStatus = !CaseStudyStatus;
        }
    }

    public void AboutSlider()
    {
        if (!AboutStatus)
        {
            About.transform.DOMoveY((screenHeight / 3.46f), time).SetEase(Ease.OutBack);
            AboutStatus = !AboutStatus;
        }
        else if (AboutStatus)
        {
            About.transform.DOMoveY(((screenHeight / 2.57f) * -1), time).SetEase(Ease.OutBack);
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
                //SceneManager.LoadScene("AR", LoadSceneMode.Single);
                Debug.Log(_button.tag);
            }
        }
        else
            Debug.Log("currentSelectedGameObject is null");
    }

}
