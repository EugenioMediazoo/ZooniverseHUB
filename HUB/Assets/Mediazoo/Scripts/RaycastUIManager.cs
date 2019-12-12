﻿using UnityEngine;
using System.Collections;
using DG.Tweening;



public class RaycastUIManager : MonoBehaviour

{
    //public GameObject london;

    public GameObject LionessGameObject;
    public GameObject GorillaGameObject;
    public GameObject LionessUI;
    public GameObject GorillaUI;


    public ParticleSystem lioness_Particles;
    public ParticleSystem gorilla_Particles;

    [Range(0.01f, 3f)]
    public float time;

    private bool lioness_tapped;
    private bool gorilla_tapped;

    private void Awake()
    {
        lioness_tapped = false;
        gorilla_tapped = false;
        LionessUI.SetActive(false);
        GorillaUI.SetActive(false);

        //london.SetActive(false);
    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("running");

            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {

                if (raycastHit.collider.CompareTag("lioness"))
                {
                    Debug.Log("Lionesse tapped");
                    lioness_Particles.Stop();
                    LionessUI.transform.DOMoveY(970, time).SetEase(Ease.OutBack);
                    lioness_tapped = true;
                }

                if (raycastHit.collider.CompareTag("gorilla"))
                {
                    Debug.Log("Gorilla tapped");
                    gorilla_Particles.Stop();
                    GorillaUI.transform.DOMoveY(970, time).SetEase(Ease.OutBack);
                    gorilla_tapped = true;
                }
            }

            if (gorilla_tapped && lioness_tapped)
            {
                //london.SetActive(true);
                //londonUI.transform.DOMoveY(970, time).SetEase(Ease.OutBack);

            }
        }
    }

    public void UISlider()
    {
        if (LionessUI.transform.localPosition.y == 970)
            LionessSlider();
        if (GorillaUI.transform.localPosition.y == 970)
            GorillaSlider();
    }


    public void LionessSlider()
    {
        LionessUI.transform.DOMoveY(-1000, time).SetEase(Ease.OutBack);
    }

    public void GorillaSlider()
    {
        GorillaUI.transform.DOMoveY(-1000, time).SetEase(Ease.OutBack);
    }
}