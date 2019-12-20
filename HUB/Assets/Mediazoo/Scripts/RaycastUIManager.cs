using UnityEngine;
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

    [Range(0.01f, 3f)]
    public float AppendTime;

    private bool lioness_tapped;
    private bool gorilla_tapped;

    private bool lionessSwipeUp;
    private bool gorillaSwipeUp;
    private bool londonSwipeUp;

    ////only for debug >>> open debug region and uncomment
    //public bool TapLioness;
    //public bool TapGorilla;
    //public bool TapLondon;

    private void Awake()
    {
        lioness_tapped = false;
        gorilla_tapped = false;

        lionessSwipeUp = false;
        gorillaSwipeUp = false;
        londonSwipeUp = false;

        London.SetActive(false);

        ////only for debug >>> open debug region and uncomment
        //TapLioness = false;
        //TapGorilla = false;
        //TapLondon = false;
    }

    void Update()
    {

        #region debug

        //if (TapLioness)
        //{
        //    TapLioness = false;

        //    Debug.Log("Lionesse tapped");
        //    lioness_Particles.Stop();
        //    //LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    lioness_tapped = true;

        //    if (gorillaSwipeUp)
        //    {
        //        lionessSwipeUp = true;
        //        gorillaSwipeUp = false;

        //        Sequence Sequence = DOTween.Sequence();
        //        Sequence.Append(GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //            .AppendInterval(AppendTime)
        //            .Append(LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (londonSwipeUp)
        //    {
        //        lionessSwipeUp = true;
        //        londonSwipeUp = false;

        //        Sequence SequenceTwo = DOTween.Sequence();
        //        SequenceTwo.Append(LondonUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //            .AppendInterval(AppendTime)
        //            .Append(LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (!gorillaSwipeUp && !londonSwipeUp)
        //    {
        //        lionessSwipeUp = true;
        //        LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    }
        //}

        //if (TapGorilla)
        //{
        //    TapGorilla = false;

        //    Debug.Log("Gorilla tapped");
        //    gorilla_Particles.Stop();
        //    //GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    gorilla_tapped = true;

        //    if (lionessSwipeUp)
        //    {
        //        gorillaSwipeUp = true;
        //        lionessSwipeUp = false;

        //        Sequence Sequence = DOTween.Sequence();
        //        Sequence.Append(LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //          .AppendInterval(AppendTime)
        //          .Append(GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (londonSwipeUp)
        //    {
        //        gorillaSwipeUp = true;
        //        londonSwipeUp = false;

        //        Sequence SequenceTwo = DOTween.Sequence();
        //        SequenceTwo.Append(LondonUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //          .AppendInterval(AppendTime)
        //          .Append(GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (!lionessSwipeUp && !londonSwipeUp)
        //    {
        //        gorillaSwipeUp = true;
        //        GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    }
        //}

        //if (TapLondon)
        //{
        //    TapLondon = false;

        //    Debug.Log("London tapped");
        //    //LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);

        //    if (lionessSwipeUp)
        //    {
        //        londonSwipeUp = true;
        //        lionessSwipeUp = false;

        //        Sequence Sequence = DOTween.Sequence();
        //        Sequence.Append(LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //          .AppendInterval(AppendTime)
        //          .Append(LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (gorillaSwipeUp)
        //    {
        //        londonSwipeUp = true;
        //        gorillaSwipeUp = false;

        //        Sequence Sequence = DOTween.Sequence();
        //        Sequence.Append(GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
        //          .AppendInterval(AppendTime)
        //          .Append(LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
        //    }
        //    else if (!lionessSwipeUp && !gorillaSwipeUp)
        //    {
        //        londonSwipeUp = true;
        //        LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
        //    }
        //}

        #endregion

        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("running");

            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                // LIONESS //
                if (raycastHit.collider.CompareTag("lioness"))
                {
                    Debug.Log("Lionesse tapped");
                    lioness_Particles.Stop();
                    //LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    lioness_tapped = true;       

                    if (gorillaSwipeUp)
                    {
                        lionessSwipeUp = true;
                        gorillaSwipeUp = false;

                        Sequence Sequence = DOTween.Sequence();
                        Sequence.Append(GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(AppendTime)
                          .Append(LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (londonSwipeUp)
                    {
                        lionessSwipeUp = true;
                        londonSwipeUp = false;

                        Sequence SequenceTwo = DOTween.Sequence();
                        SequenceTwo.Append(LondonUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(AppendTime)
                          .Append(LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (!gorillaSwipeUp && !londonSwipeUp)
                    {
                        lionessSwipeUp = true;
                        LionessUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    }
                }

                // GORILLA //
                if (raycastHit.collider.CompareTag("gorilla"))
                {
                    Debug.Log("Gorilla tapped");
                    gorilla_Particles.Stop();
                    //GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    gorilla_tapped = true;

                    if (lionessSwipeUp)
                    {
                        gorillaSwipeUp = true;
                        lionessSwipeUp = false;

                        Sequence Sequence = DOTween.Sequence();
                        Sequence.Append(LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(AppendTime)
                          .Append(GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (londonSwipeUp)
                    {
                        gorillaSwipeUp = true;
                        londonSwipeUp = false;

                        Sequence SequenceTwo = DOTween.Sequence();
                        SequenceTwo.Append(LondonUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(AppendTime)
                          .Append(GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (!lionessSwipeUp && !londonSwipeUp)
                    {
                        gorillaSwipeUp = true;
                        GorillaUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    }
                }

                // LONDON //
                if (raycastHit.collider.CompareTag("london"))
                {
                    Debug.Log("London tapped");
                    //LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);

                    if (lionessSwipeUp)
                    {
                        londonSwipeUp = true;
                        lionessSwipeUp = false;

                        Sequence Sequence = DOTween.Sequence();
                        Sequence.Append(LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(AppendTime)
                          .Append(LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (gorillaSwipeUp)
                    {
                        londonSwipeUp = true;
                        gorillaSwipeUp = false;

                        Sequence Sequence = DOTween.Sequence();
                        Sequence.Append(GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack))
                          .AppendInterval(AppendTime)
                          .Append(LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack));
                    }
                    else if (!lionessSwipeUp && !gorillaSwipeUp)
                    {
                        londonSwipeUp = true;
                        LondonUI.transform.DOMoveY(450, time).SetEase(Ease.OutBack);
                    }
                }
            }
        }

        if (gorilla_tapped && lioness_tapped && !London.activeSelf)
        {
            //Debug.Log("LondonActive");
            London.SetActive(true);

            //Debug.Log(London.transform.position);
            //Debug.Log(London.transform.rotation);
        }
    }

    public void UISlider()
    {
        if (lionessSwipeUp)
            LionessSlider();
        if (gorillaSwipeUp)
            GorillaSlider();
        if (londonSwipeUp)
            LondonSlider();
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

    public void ClearSliders()
    {
        LionessUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        lionessSwipeUp = false;
        GorillaUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        gorillaSwipeUp = false;
        LondonUI.transform.DOMoveY(-450, time).SetEase(Ease.OutBack);
        londonSwipeUp = false;

        lioness_tapped = false;
        gorilla_tapped = false;
        London.SetActive(false);

    }
}