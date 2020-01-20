using System.Collections;
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
    private bool Show = true;

    public void Awake()
    {
        if (time == 0)
            time = 0.8f;
        else
            return;
    }

    public void ShowHideMenu()
    {
        if (Show)
        {
            MenuBar.transform.DOLocalMoveY(0, time).SetEase(Ease.InOutQuad);
            Show =! Show;
        }
        else if (!Show)
        {
            MenuBar.transform.DOLocalMoveY(900, time).SetEase(Ease.InOutQuad);
            Show =! Show;
        }
    }
    
}
