﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseStudySwipeDetectorSwipe : MonoBehaviour
{
    [HideInInspector]
    public bool selected = false;

    public void changeBool()
    {
        selected = !selected;
        Invoke("changeBack", 1);
        Debug.Log("Buttonswipe ready");
    }

    void changeBack()
    {
        selected = !selected;
        Debug.Log("Button deselected");
    }
}
