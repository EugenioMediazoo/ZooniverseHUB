﻿using UnityEngine;
using System.Collections;
using DG.Tweening;



public class RaycastUIManager : MonoBehaviour

{
    public GameObject LionessUI;
    public GameObject GorillaUI;
    public GameObject LondonUI;

    public ParticleSystem lioness_Particles;
    public ParticleSystem gorilla_Particles;

    public GameObject London;

    [Range(0.01f, 3f)]
    public float time;

    private bool lioness_tapped;
    private bool gorilla_tapped;

    private bool lionessSwipeUp;
    private bool gorillaSwipeUp;
    private bool londonSwipeUp;

    ////only for debug >>> open debug region and uncomment
    //public bool TapLioness;
    //public bool TapGorilla;

    private void Awake()
    {
        lioness_tapped = false;
        gorilla_tapped = false;

        lionessSwipeUp = false;
        gorillaSwipeUp = false;
        londonSwipeUp = false;

        London.SetActive(false);

        //TapLioness = false;
        //TapGorilla = false;
    }

    void Update()
    {

        #region debug
        //if (TapLioness)
        //{
        //    TapLioness = false;

        //    Debug.Log("Lionesse tapped");
        //    lioness_Particles.Stop();
        //    LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    lioness_tapped = true;
        //    lionessSwipeUp = true;

        //    if (gorillaSwipeUp)
        //    {
        //        Sequence gorillaSequence = DOTween.Sequence();
        //        gorillaSequence.Append(GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //          .AppendInterval(0.5f)
        //          .Append(LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (!gorillaSwipeUp && !lionessSwipeUp)
        //    {
        //        LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    }
        //}

        //if (TapGorilla)
        //{
        //    TapGorilla = false;

        //    Debug.Log("Gorilla tapped");
        //    gorilla_Particles.Stop();
        //    GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    gorilla_tapped = true;
        //    gorillaSwipeUp = true;

        //    if (lionessSwipeUp)
        //    {
        //        Sequence gorillaSequence = DOTween.Sequence();
        //        gorillaSequence.Append(LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //          .AppendInterval(0.5f)
        //          .Append(GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (!lionessSwipeUp && !gorillaSwipeUp)
        //    {
        //        GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    }
        //}

        //if (gorilla_tapped && lioness_tapped)
        //{
        //    London.SetActive(true);
        //}
        #endregion

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
                    LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    lioness_tapped = true;
                    lionessSwipeUp = true;

                    if (gorillaSwipeUp)
                    {
                        Sequence gorillaSequence = DOTween.Sequence();
                        gorillaSequence.Append(GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(0.5f)
                          .Append(LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (!gorillaSwipeUp && !lionessSwipeUp)
                    {
                        LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    }

                }

                if (raycastHit.collider.CompareTag("gorilla"))
                {
                    Debug.Log("Gorilla tapped");
                    gorilla_Particles.Stop();
                    GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    gorilla_tapped = true;
                    gorillaSwipeUp = true;

                    if (lionessSwipeUp)
                    {
                        Sequence gorillaSequence = DOTween.Sequence();
                        gorillaSequence.Append(LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(0.5f)
                          .Append(GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (!lionessSwipeUp && !gorillaSwipeUp)
                    {
                        GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    }
                }
                if (raycastHit.collider.CompareTag("london"))
                {
                    Debug.Log("London tapped");
                    LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    londonSwipeUp = true;
                }
            }

            //if (gorilla_tapped && lioness_tapped)
            //{
            //    London.SetActive(true);
            //}
        }

        if (gorilla_tapped && lioness_tapped)
        {
            Debug.Log("LondonActive");
            London.SetActive(true);
        }
    }

    public void UISlider()
    {
        if (lionessSwipeUp)
            LionessSlider();
        if (gorillaSwipeUp)
            GorillaSlider();
    }


    public void LionessSlider()
    {
        LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        lionessSwipeUp = false;
    }

    public void GorillaSlider()
    {
        GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        gorillaSwipeUp = false;
    }

    public void LondonSlider()
    {
        LondonUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        londonSwipeUp = false;
    }
}