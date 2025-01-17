﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    //gameobject
    public GameObject MenuBar;

    //time
    [Range(0.01f, 3f)]
    public float time;

    //bool
    private bool Show = false;

    public void Awake()
    {
        if (time == 0)
            time = 0.8f;
        else
            return;

        Invoke("HideOnLoad", 5);
        //Debug.Log("test");
    }

    public void ShowHideMenu()
    {
        if (Show)
        {
            MenuBar.transform.DOLocalMoveY(-325, time).SetEase(Ease.InOutQuad);
            Show =! Show;
        }
        else if (!Show)
        {
            MenuBar.transform.DOLocalMoveY(325, time).SetEase(Ease.InOutQuad);
            Show =! Show;
        }
    }

    public void HideOnLoad()
    {
        MenuBar.transform.DOLocalMoveY(325, time).SetEase(Ease.InOutQuad);
        Show = !Show;
    }
    
}
