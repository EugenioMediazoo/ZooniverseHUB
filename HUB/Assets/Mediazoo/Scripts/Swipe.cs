using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    //scripts
    public UIManagerHUB ManagerUI;
    public RaycastUIManager RaycastUI;

    //swipe variables
    [Range(0.1f, 10f)]
    public float minTime;
    [Range(0.1f, 10f)]
    public float maxTime;
    [Range(10, 1000)]
    public int minSwipeDist;

    float startTime;
    float endTime;

    Vector3 startPos;
    Vector3 endPos;

    float swipeDist;
    float swipeTime;
    float buttonDividerLow;
    float buttonDividerHigh;

    private void Awake()
    {
        if(ManagerUI != null)
        {
            UIManagerHUB ManagerUI = GetComponent<UIManagerHUB>();
        }

        if (RaycastUI != null)
        {
            RaycastUIManager RaycastUI = GetComponent<RaycastUIManager>();
        }

        buttonDividerLow = Screen.height / 8;
        buttonDividerHigh = (Screen.height / 8)*6;
    }

    void Start()
    {
        minTime = 0.2f;
        maxTime = 1f;
        minSwipeDist = 50;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;

                Debug.Log(startPos.y);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDist = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime > minTime && swipeTime < maxTime && swipeDist > minSwipeDist)
                {
                    Swipeing();
                }
            }
        }
    }

    void Swipeing()
    {
        Vector2 distance = endPos - startPos;
        
        #region HORIZONTAL SWIPE
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            //Debug.Log("horizontal Swipe");

            if (distance.x > 0)
            {
                Debug.Log("Right Swipe");
            }
            else if (distance.x < 0)
            {
                Debug.Log("Left Swipe");
            }
        }
        #endregion
        #region VERTICAL SWIPE
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if (distance.y > 0)
            {
                Debug.Log("Up Swipe");

                if (startPos.y > buttonDividerLow)
                {
                    if (ManagerUI != null)
                    {
                        ManagerUI.CaseStudySlider();
                    }
                }
                else if(startPos.y < buttonDividerLow)
                {
                    if (ManagerUI != null)
                    {
                        ManagerUI.AboutSlider();
                    }
                }
            }

            else if (distance.y < 0)
            {
                Debug.Log("Down Swipe");

                if (startPos.y > buttonDividerHigh)
                {
                    if(ManagerUI != null)
                    {
                        ManagerUI.CaseStudySlider();
                    }  
                }
                else if (startPos.y < buttonDividerHigh)
                {
                    if (ManagerUI != null)
                    {
                        ManagerUI.AboutSlider();
                    }
                }
                
                if (RaycastUI != null)
                {
                    RaycastUI.UISlider();
                    Debug.Log("SWipeDown");
                }
            }
        }
        #endregion
    }
}
