using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Swipe : MonoBehaviour
{
    //animation variable
    public GameObject Container;
    public UIManagerScript _MoveUI;

    //swipe variables
    [Range(0.1f, 10f)]
    public float minTime;
    [Range(0.1f, 10f)]
    public float maxTime;
    [Range(100, 1000)]
    public int minSwipeDist;

    float startTime;
    float endTime;

    Vector3 startPos;
    Vector3 endPos;

    float swipeDist;
    float swipeTime;

    // Start is called before the first frame update
    void Start()
    {
        minTime = 0.2f;
        maxTime = 1f;
        minSwipeDist = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;

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
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            Debug.Log("horizontal Swipe");

            if (distance.x > 0)
            {
                Debug.Log("Right Swipe");
            }
            else if (distance.x < 0)
            {
                Debug.Log("Left Swipe");
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            Debug.Log("vertical Swipe");

            if (distance.y > 0)
            {
                Debug.Log("Up Swipe");
                Container.transform.DOMoveY(Screen.height/3f, _MoveUI.time).SetEase(Ease.OutBack);
            }
            else if (distance.y < 0)
            {
                Debug.Log("Down Swipe");
                Container.transform.DOMoveY(0, _MoveUI.time).SetEase(Ease.OutBack);
            }
        }
    }
}
